using IronOcr;
using System.Data;
using System.Runtime.Versioning;

namespace DigitalizadorRG
{
    public class BLL_BuildImage
    {
        private Image _image { get; set; }
        private Bitmap _map { get; set; }
        private Graphics _grap { get; set; }
        public Dictionary<string, Rectangle> DictionaryDropImage;

        public BLL_BuildImage(Image image)
        {
            _image = image;
            _map = new Bitmap(image);
            _grap = Graphics.FromImage(_map);
            DictionaryDropImage = new Dictionary<string, Rectangle>();
        }

        public void AddDictionary(string key, Rectangle rectangle) => DictionaryDropImage.Add(key, rectangle);

        public Bitmap ForeachRectangle()
        {
            foreach (Rectangle rectangle in DictionaryDropImage.Values)
                _grap.DrawRectangle(new Pen(Color.Red, 1), rectangle);
            return _map;
        }

        public DataTable CarregarImages()
        {
            Dictionary<string, Image> images = new Dictionary<string, Image>();

            try
            {
                images.Add("NOME", CarregarDrop(_map, DictionaryDropImage["NOME"]));
                images.Add("RG", CarregarDrop(_map, DictionaryDropImage["RG"]));
                images.Add("CPF", CarregarDrop(_map, DictionaryDropImage["CPF"]));
                images.Add("DTNASC", CarregarDrop(_map, DictionaryDropImage["DTNASC"]));
                return CarragarDataGrid(images);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private DataTable CarragarDataGrid(Dictionary<string, Image> imgs)
        {
            string[] rgs = CarregarFiles(imgs);

            DataTable dt = new DataTable();
            DataRow row;

            dt.Columns.Add("Nome Completo", typeof(string));
            dt.Columns.Add("RG", typeof(string));
            dt.Columns.Add("CPF", typeof(string));
            dt.Columns.Add("Nome Usuario", typeof(string));
            dt.Columns.Add("Data Digitalização", typeof(DateTime));

            row = dt.NewRow();
            row["Nome Completo"] = rgs[0].Replace(".", "").Replace("-", "").Replace("/", "").Replace(",", "");
            row["RG"] = rgs[1].Replace(".", "").Replace("-", "").Replace("/", "").Replace(",", "");
            row["CPF"] = rgs[2].Replace(".", "").Replace("-", "").Replace("/", "").Replace(",", "");
            row["Nome Usuario"] = Environment.UserName;
            row["Data Digitalização"] = DateTime.Now;
            dt.Rows.Add(row);

            return dt;
        }

        [SupportedOSPlatform("windows")]
        private string[] CarregarFiles(Dictionary<string, Image> imgs)
        {
            int i = 0;
            var ocr = new IronTesseract();
            string[] str = new string[imgs.Count];

            foreach (Image img in imgs.Values)
                using (var imput = new OcrInput(img))
                {
                    var res = ocr.Read(imput);
                    str[i++] = res.Text;
                }
            return str;
        }

        [SupportedOSPlatform("windows")]
        private Image CarregarDrop(Image img, Rectangle drop)
        {
            Bitmap target = new Bitmap(drop.Width, drop.Height);
            Rectangle dest = new Rectangle(0, 0, drop.Width, drop.Height);
            Rectangle src = drop;

            using (Graphics g = Graphics.FromImage(target))
                g.DrawImage(img, dest, src, GraphicsUnit.Pixel);

            return target;
        }

    }
}