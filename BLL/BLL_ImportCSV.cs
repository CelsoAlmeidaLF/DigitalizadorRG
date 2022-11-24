using System.Data;
using System.Text;

namespace DigitalizadorRG
{
    public class BLL_ImportCSV
    {
        public void ExportarDataTableCSV(string caminho, string nome, DataTable data)
        {
            string separador = "|";

            try
            {
                if (caminho == null || nome == null || data == null)
                    throw new NullReferenceException("Parâmetro informado inválido!");

                caminho = caminho.LastIndexOf("\\") != caminho.Length - 1 ? caminho + "\\" : caminho;
                nome = nome.LastIndexOf(".csv") != nome.Length - 5 ? nome + ".csv" : nome;
                GravarCabecalho(caminho + nome, data, separador);
                GravarConteudo(caminho + nome, data, separador);

            }
            catch (Exception ex) { throw; }
        }

        public void GravarCabecalho(string caminho, DataTable data, string separador)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminho, false, Encoding.Default))
                {
                    writer.BaseStream.Seek(0, SeekOrigin.End);
                    for (int indexColuna = 0; indexColuna <= data.Columns.Count - 1; indexColuna++)
                    {
                        writer.Write(data.Columns[indexColuna].ColumnName);
                        if (indexColuna != data.Columns.Count - 1)
                            writer.Write(separador);
                    }
                    writer.WriteLine();
                }
            }
            catch (Exception ex) { throw; }
        }

        public void GravarConteudo(string caminho, DataTable data, string separador)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminho, true, Encoding.Default))
                {
                    foreach (DataRow linha in data.Rows)
                    {
                        for (int indexColuna = 0; indexColuna <= data.Columns.Count - 1; indexColuna++)
                        {
                            string celula = linha[indexColuna] != DBNull.Value ? linha[indexColuna].ToString().Replace("\n", "") : null;
                            writer.Write(celula);
                            if (indexColuna != data.Columns.Count - 1) writer.Write(separador);
                        }
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception ex) { throw; }
        }
    }
}