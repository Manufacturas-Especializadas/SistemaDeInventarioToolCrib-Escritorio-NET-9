using Microsoft.Data.SqlClient;
using SistemaDeInventarioToolCrib.Utilities;
using System.Data;
using System.Threading.Tasks;

namespace SistemaDeInventarioToolCrib
{
    public partial class ToolCrib : Form
    {
        private int paginaActual = 1;
        private int filasPorPagina = 20;
        private DataTable tablaCompleta = new DataTable();
        private int? currentMaterialId = null;
        private string currentSku = string.Empty;

        public ToolCrib()
        {
            InitializeComponent();
        }

        private async void ToolCrib_Load(object sender, EventArgs e)
        {
            ConfigurarEstiloDataGridView();
            await LoadData();
        }

        private void ConfigurarEstiloDataGridView()
        {
            dtGdVwEntrance.Font = new Font("Arial", 12);
            dtGdVwEntrance.DefaultCellStyle.Font = new Font("Arial", 12);
            dtGdVwEntrance.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dtGdVwEntrance.RowHeadersVisible = false;

            dtGdVwEntrance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtGdVwEntrance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGdVwEntrance.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private async void txtBxEntrance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                string barcode = txtBxEntrance.Text.Trim();
                txtBxEntrance.SelectAll();

                if (string.IsNullOrWhiteSpace(barcode))
                {
                    return;
                }

                if (!string.IsNullOrEmpty(currentSku) && barcode == currentSku)
                {
                    await UpdateStockAsync(currentMaterialId!.Value);
                }
                else
                {
                    bool found = await SearchMaterialByPartNumberAsync(barcode);

                    if (found)
                    {
                        await ShowOnlyRegister(currentMaterialId!.Value);
                    }
                    else
                    {
                        MessageBox.Show("Sku no encontrado");
                        txtBxEntrance.Clear();
                    }
                }
            }
        }

        private void txtBxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                string searchText = txtBxSearch.Text.Trim();
                ShowPage(1, searchText);
            }
        }

        private async Task<bool> SearchMaterialByPartNumberAsync(string sku)
        {
            try
            {
                using (SqlConnection conn = await Connection.GetConnectionAsync())
                {
                    if (conn == null || conn.State != ConnectionState.Open)
                    {
                        return false;
                    }

                    string query = "SELECT Id FROM TOOLCRIB WHERE sku = @sku";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sku", sku);

                        var result = await cmd.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            currentMaterialId = id;
                            currentSku = sku;
                            return true;
                        }

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el número de parte: {ex.Message}");
                return false;
            }
        }

        private async Task LoadData()
        {
            string query = @"
                            SELECT
                                Id, sku, material,existencia,
                                minimo, maximo,
                                linea, comentarios, categoria, fecha, hora,
                                ubicacion, unidadDeMedida,
                                proveedor, numeroDeSerie, costoUnitario,
                                ramos, santa, aluminio, cobre, modificado
                            FROM TOOLCRIB
                            ORDER BY Id DESC";

            tablaCompleta.Clear();

            using (SqlConnection conn = await Connection.GetConnectionAsync())
            {
                if (conn == null || conn.State != ConnectionState.Open)
                {
                    MessageBox.Show("No se pudo conectar a la base de datos");

                    return;
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        tablaCompleta.Load(reader);
                    }
                }
            }
            tablaCompleta.PrimaryKey = new DataColumn[] { tablaCompleta.Columns["Id"]! };

            ShowPage(paginaActual);
        }

        private void ShowPage(int pagina, string filtroMaterial = "")
        {
            if (tablaCompleta.Rows.Count == 0)
            {
                dtGdVwEntrance.DataSource = null;
                lbPage.Text = "Página 0 de 0";
                return;
            }

            DataTable tablaFiltrada = tablaCompleta;
            if (!string.IsNullOrEmpty(filtroMaterial))
            {
                tablaFiltrada = tablaCompleta.Clone();
                foreach (DataRow row in tablaCompleta.Rows)
                {
                    if (row["material"].ToString()!.IndexOf(filtroMaterial, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        tablaFiltrada.ImportRow(row);
                    }
                }

                if(tablaFiltrada.Rows.Count == 0)
                {
                    dtGdVwEntrance.DataSource = null;
                    lbPage.Text = "Página 0 de 0";
                    MessageBox.Show($"No se encontraron materiales que coincidan con '{filtroMaterial}'",
                         "Búsqueda sin resultados",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
                    return;
                }
            }

            int totalFila = tablaFiltrada.Rows.Count;
            int totalPages = (int)Math.Ceiling((double)totalFila / filasPorPagina);

            if (pagina < 1) pagina = 1;
            if (pagina > totalPages) pagina = totalPages;

            paginaActual = pagina;

            int filaInicio = (pagina - 1) * filasPorPagina;
            DataTable paginaTabla = tablaFiltrada.Clone();
            int count = 0;

            for (int i = filaInicio; i < tablaFiltrada.Rows.Count && count < filasPorPagina; i++, count++)
            {
                paginaTabla.ImportRow(tablaFiltrada.Rows[i]);
            }

            RenameColumns(paginaTabla);

            dtGdVwEntrance.DataSource = paginaTabla;
            dtGdVwEntrance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtGdVwEntrance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGdVwEntrance.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            lbPage.Text = $"Página {paginaActual} de {totalPages}";
        }

        private async Task ShowOnlyRegister(int id)
        {
            try
            {
                using (SqlConnection conn = await Connection.GetConnectionAsync())
                {
                    if (conn == null || conn.State != ConnectionState.Open)
                    {
                        MessageBox.Show("No se pudo conectar a la base de datos");
                        return;
                    }

                    string query = @"
                                SELECT 
                                    Id, sku, material,existencia, minimo, maximo,
                                    linea, comentarios, categoria, fecha, hora,
                                    ubicacion, unidadDeMedida,
                                    proveedor, numeroDeSerie, costoUnitario,
                                    ramos, santa, aluminio, cobre, modificado
                                FROM TOOLCRIB
                                WHERE Id = @id;
                            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            DataTable filteredTable = new DataTable();
                            filteredTable.Load(reader);

                            if (filteredTable.Rows.Count > 0)
                            {
                                RenameColumns(filteredTable);
                                dtGdVwEntrance.DataSource = filteredTable;
                                lbPage.Text = "Página 1 de 1";
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el registro");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el registro actualizado: {ex.Message}");
            }
        }

        private void RenameColumns(DataTable dt)
        {
            if (dt.Columns.Contains("sku")) dt.Columns["sku"]!.ColumnName = "Sku";
            if (dt.Columns.Contains("existencia")) dt.Columns["existencia"]!.ColumnName = "Existencia";
            if (dt.Columns.Contains("minimo")) dt.Columns["minimo"]!.ColumnName = "Minimo";
            if (dt.Columns.Contains("maximo")) dt.Columns["maximo"]!.ColumnName = "Maximo";
            if (dt.Columns.Contains("linea")) dt.Columns["linea"]!.ColumnName = "Linea";
            if (dt.Columns.Contains("comentarios")) dt.Columns["comentarios"]!.ColumnName = "Comentarios";
            if (dt.Columns.Contains("categoria")) dt.Columns["categoria"]!.ColumnName = "Categoria";
            if (dt.Columns.Contains("ubicacion")) dt.Columns["ubicacion"]!.ColumnName = "Ubicacion";
            if (dt.Columns.Contains("fecha")) dt.Columns["fecha"]!.ColumnName = "Fecha";
            if (dt.Columns.Contains("hora")) dt.Columns["hora"]!.ColumnName = "Hora";
            if (dt.Columns.Contains("material")) dt.Columns["material"]!.ColumnName = "Material";
            if (dt.Columns.Contains("modificado")) dt.Columns["modificado"]!.ColumnName = "Modificado";
            if (dt.Columns.Contains("unidadDeMedida")) dt.Columns["unidadDeMedida"]!.ColumnName = "Unidad de medida";
            if (dt.Columns.Contains("proveedor")) dt.Columns["proveedor"]!.ColumnName = "Proveedor";
            if (dt.Columns.Contains("numeroDeSerie")) dt.Columns["numeroDeSerie"]!.ColumnName = "Numero de serie";
            if (dt.Columns.Contains("costoUnitario")) dt.Columns["costoUnitario"]!.ColumnName = "Costo unitario";
            if (dt.Columns.Contains("ramos")) dt.Columns["ramos"]!.ColumnName = "Ramos";
            if (dt.Columns.Contains("santa")) dt.Columns["santa"]!.ColumnName = "Santa";
            if (dt.Columns.Contains("aluminio")) dt.Columns["aluminio"]!.ColumnName = "Aluminio";
            if (dt.Columns.Contains("cobre")) dt.Columns["cobre"]!.ColumnName = "Cobre";
        }

        private async void dtGdVwEntrance_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var row = dtGdVwEntrance.Rows[e.RowIndex];
            string columName = dtGdVwEntrance.Columns[e.ColumnIndex].Name;

            object newValue = row.Cells[e.ColumnIndex].Value!;

            if (!int.TryParse(row.Cells["Id"].Value?.ToString(), out int id))
            {
                MessageBox.Show("No se puedo obtener un ID válido");

                return;
            }

            await UpdateDatabaseAsync(id, columName, newValue);
        }

        private async Task UpdateDatabaseAsync(int id, string columnName, object newValue)
        {
            try
            {
                using (SqlConnection conn = await Connection.GetConnectionAsync())
                {
                    if (conn == null || conn.State != ConnectionState.Open)
                    {
                        MessageBox.Show("No se pudo conectar a la base de datos");

                        return;
                    }

                    string query = $"UPDATE TOOLCRIB SET [{columnName}] = @value WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@value", newValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Id", id);

                        int rowAffected = await cmd.ExecuteNonQueryAsync();

                        if (rowAffected > 0)
                        {
                            MessageBox.Show("Campo actualizado");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el registro para actualizar");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task UpdateStockAsync(int id)
        {
            try
            {
                using (SqlConnection conn = await Connection.GetConnectionAsync())
                {
                    if (conn == null || conn.State != ConnectionState.Open)
                    {
                        return;
                    }

                    string query = "UPDATE TOOLCRIB SET existencia = existencia + 1 WHERE Id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        int rowAffected = await cmd.ExecuteNonQueryAsync();

                        if (rowAffected > 0)
                        {
                            DataRow row = tablaCompleta.Rows.Find(id)!;

                            if (row != null)
                            {
                                row["existencia"] = Convert.ToInt32(row["existencia"]) + 1;

                                await ShowOnlyRegister(id);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar existencias: {ex.Message}");
            }
        }

        private async Task<bool> DeleteFromDataBaseAsync(int id)
        {
            try
            {
                using (SqlConnection conn = await Connection.GetConnectionAsync())
                {
                    if (conn == null || conn.State != ConnectionState.Open)
                    {
                        MessageBox.Show("No se pudo conectar a la base de datos");
                        return false;
                    }

                    string query = "DELETE FROM TOOLCRIB WHERE Id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el registro: {ex.Message}");

                return false;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtGdVwEntrance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar");
                return;
            }

            DataGridViewRow selectedRow = dtGdVwEntrance.SelectedRows[0];

            if (!int.TryParse(selectedRow.Cells["Id"].Value?.ToString(), out int id))
            {
                MessageBox.Show("No se pudo obtener un ID valido");
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar este registro?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool eliminando = await DeleteFromDataBaseAsync(id);

                if (eliminando)
                {
                    await LoadData();
                    MessageBox.Show("Registro eliminando correctamente");
                }
                else
                {
                    MessageBox.Show("Hubo un error al eliminar el registro");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                ShowPage(paginaActual - 1);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalFilas = tablaCompleta.Rows.Count;
            int totalPages = (int)Math.Ceiling((double)totalFilas / filasPorPagina);

            if (paginaActual < totalPages)
            {
                ShowPage(paginaActual + 1);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            currentMaterialId = null;
            currentSku = string.Empty;
            txtBxEntrance.Clear();
            txtBxSearch.Clear();

            ShowPage(1);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ToolCrib_Registro registro = new ToolCrib_Registro();
            registro.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ToolCrib_Salidas salidas = new ToolCrib_Salidas();
            salidas.Show();
            this.Hide();
        }
    }
}