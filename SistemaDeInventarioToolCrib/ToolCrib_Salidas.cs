﻿using Microsoft.Data.SqlClient;
using SistemaDeInventarioToolCrib.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeInventarioToolCrib
{
    public partial class ToolCrib_Salidas : Form
    {
        private int paginaActual = 1;
        private int filasPorPagina = 20;
        private DataTable tablaCompleta = new DataTable();
        private int? currentMaterialId = null;
        private string currentPartNumber = string.Empty;

        public ToolCrib_Salidas()
        {
            InitializeComponent();
        }

        private async void ToolCrib_Salidas_Load(object sender, EventArgs e)
        {
            ConfigurarEstiloDataGridView();
            await LoadData();
        }

        private void ConfigurarEstiloDataGridView()
        {
            dtGdVwExit.Font = new Font("Arial", 12);
            dtGdVwExit.DefaultCellStyle.Font = new Font("Arial", 12);
            dtGdVwExit.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dtGdVwExit.RowHeadersVisible = false;

            dtGdVwExit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtGdVwExit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGdVwExit.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private async void txtBxExit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                string barcode = txtBxExit.Text.Trim();
                txtBxExit.SelectAll();

                if (string.IsNullOrEmpty(barcode))
                {
                    return;
                }

                if (!string.IsNullOrEmpty(currentPartNumber) && barcode == currentPartNumber)
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
                        MessageBox.Show("Número de parte no encotrado");
                        txtBxExit.Clear();
                    }
                }
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
                            currentPartNumber = sku;
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
                                Id, sku, existencia,
                                minimo, maximo,
                                linea, comentarios, categoria, fecha, hora,
                                ubicacion, material, unidadDeMedida,
                                proveedor, numeroDeSerie, costoUnitario,
                                ramos, santa, aluminio, cobre, modificado
                            FROM TOOLCRIB";

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

        private void ShowPage(int pagina)
        {
            if (tablaCompleta.Rows.Count == 0)
            {
                dtGdVwExit.DataSource = null;
                lbPage.Text = "Página 0 de 0";

                return;
            }

            int totalFila = tablaCompleta.Rows.Count;
            int totalPages = (int)Math.Ceiling((double)totalFila / filasPorPagina);

            if (pagina < 1) pagina = 1;
            if (pagina > totalPages) pagina = totalPages;

            paginaActual = pagina;

            int filaIncio = (pagina - 1) * filasPorPagina;

            DataTable paginaTabla = tablaCompleta.Clone();
            int count = 0;


            for (int i = filaIncio; i < tablaCompleta.Rows.Count && count < filasPorPagina; i++, count++)
            {
                paginaTabla.ImportRow(tablaCompleta.Rows[i]);
            }


            paginaTabla.Columns["sku"]!.ColumnName = "Sku";
            paginaTabla.Columns["existencia"]!.ColumnName = "Existencia";
            paginaTabla.Columns["minimo"]!.ColumnName = "Minimo";
            paginaTabla.Columns["maximo"]!.ColumnName = "Maximo";
            paginaTabla.Columns["linea"]!.ColumnName = "Linea";
            paginaTabla.Columns["comentarios"]!.ColumnName = "Comentarios";
            paginaTabla.Columns["categoria"]!.ColumnName = "Categoria";
            paginaTabla.Columns["ubicacion"]!.ColumnName = "Ubicacion";
            paginaTabla.Columns["fecha"]!.ColumnName = "Fecha";
            paginaTabla.Columns["hora"]!.ColumnName = "Hora";
            paginaTabla.Columns["material"]!.ColumnName = "Material";
            paginaTabla.Columns["modificado"]!.ColumnName = "Modificado";
            paginaTabla.Columns["unidadDeMedida"]!.ColumnName = "Unidad de medida";
            paginaTabla.Columns["proveedor"]!.ColumnName = "Proveedor";
            paginaTabla.Columns["numeroDeSerie"]!.ColumnName = "Numero de serie";
            paginaTabla.Columns["costoUnitario"]!.ColumnName = "Costo unitario";
            paginaTabla.Columns["ramos"]!.ColumnName = "Ramos";
            paginaTabla.Columns["santa"]!.ColumnName = "Santa";
            paginaTabla.Columns["aluminio"]!.ColumnName = "Aluminio";
            paginaTabla.Columns["cobre"]!.ColumnName = "Cobre";

            dtGdVwExit.DataSource = paginaTabla;

            dtGdVwExit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dtGdVwExit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dtGdVwExit.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

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
                                    Id, sku, existencia, minimo, maximo,
                                    linea, comentarios, categoria, fecha, hora,
                                    ubicacion, material, unidadDeMedida,
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
                                dtGdVwExit.DataSource = filteredTable;
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
                MessageBox.Show($"No se encontró el registro: {ex.Message}");
            }
        }

        private void RenameColumns(DataTable dt)
        {
            dt.Columns["sku"]!.ColumnName = "Sku";
            dt.Columns["existencia"]!.ColumnName = "Existencia";
            dt.Columns["minimo"]!.ColumnName = "Minimo";
            dt.Columns["maximo"]!.ColumnName = "Maximo";
            dt.Columns["linea"]!.ColumnName = "Linea";
            dt.Columns["comentarios"]!.ColumnName = "Comentarios";
            dt.Columns["categoria"]!.ColumnName = "Categoria";
            dt.Columns["ubicacion"]!.ColumnName = "Ubicacion";
            dt.Columns["fecha"]!.ColumnName = "Fecha";
            dt.Columns["hora"]!.ColumnName = "Hora";
            dt.Columns["material"]!.ColumnName = "Material";
            dt.Columns["modificado"]!.ColumnName = "Modificado";
            dt.Columns["unidadDeMedida"]!.ColumnName = "Unidad de medida";
            dt.Columns["proveedor"]!.ColumnName = "Proveedor";
            dt.Columns["numeroDeSerie"]!.ColumnName = "Numero de serie";
            dt.Columns["costoUnitario"]!.ColumnName = "Costo unitario";
            dt.Columns["ramos"]!.ColumnName = "Ramos";
            dt.Columns["santa"]!.ColumnName = "Santa";
            dt.Columns["aluminio"]!.ColumnName = "Aluminio";
            dt.Columns["cobre"]!.ColumnName = "Cobre";
        }

        private async void dtGdVwExit_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var row = dtGdVwExit.Rows[e.RowIndex];
            string columnName = dtGdVwExit.Columns[e.ColumnIndex].Name;

            object newValue = row.Cells[e.ColumnIndex].Value!;

            if (!int.TryParse(row.Cells["Id"].Value?.ToString(), out int id))
            {
                MessageBox.Show("No se pudo obtener un ID válido");

                return;
            }

            await UpdateDatabaseAsync(id, columnName, newValue);
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

                    string query = "UPDATE TOOLCRIB SET existencia = existencia - 1 WHERE Id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        int rowAffected = await cmd.ExecuteNonQueryAsync();

                        if (rowAffected > 0)
                        {
                            DataRow row = tablaCompleta.Rows.Find(id)!;

                            if (row != null)
                            {
                                row["existencia"] = Convert.ToInt32(row["existencia"]) - 1;

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
            if (dtGdVwExit.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar");

                return;
            }

            DataGridViewRow selectedRow = dtGdVwExit.SelectedRows[0];

            if (!int.TryParse(selectedRow.Cells["Id"].Value?.ToString(), out int id))
            {
                MessageBox.Show("No se pudo obtener un ID valido");
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalFila = tablaCompleta.Rows.Count;
            int totalPages = (int)Math.Ceiling((double)totalFila / filasPorPagina);

            if (paginaActual < totalPages)
            {
                ShowPage(paginaActual + 1);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                ShowPage(paginaActual - 1);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            currentMaterialId = null;
            currentPartNumber = string.Empty;

            ShowPage(1);
        }

        private void btnEntrance_Click(object sender, EventArgs e)
        {
            ToolCrib Entradas = new ToolCrib();
            Entradas.Show();
            this.Hide();
        }
    }
}
