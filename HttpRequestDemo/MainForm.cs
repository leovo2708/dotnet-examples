using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpRequestDemo
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            sendButton.Enabled = false;
            try
            {
                var content = await DownloadPage(urlTextBox.Text);
                responseTextBox.Text = content;
            }
            catch(Exception exception)
            {
                responseTextBox.Text = exception.Message;
            }

            sendButton.Enabled = true;
        }

        private async Task<string> DownloadPage(string url)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return content;
                }
            }
        }
    }
}
