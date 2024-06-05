using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Veterinaria.Models;

namespace Veterinaria.Controllers.Mail
{
    public class MailController
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public MailController()
        {
            _httpClient = new HttpClient();
            _apiKey = "mlsn.2063e271f9565024f70ac5fa583703a573db71b562d6c1f569ce406f5749e429";
        }

        public async Task EnviarCorreo(string emailOwner, string namesOwner, string lastNameOwner)
        {
            try
            {
                string url = "https://api.mailersend.com/v1/email";

                var emailMessage = new Email
                {
                    from = new From { email = "MS_5anJzo@trial-3vz9dle77mq4kj50.mlsender.net" },
                    to = new[]
                    {
                        new To { email = emailOwner }
                    },
                    subject = "Cita Veterinaria Programada",
                    text = $"Estimado(a) {namesOwner} {lastNameOwner},\n\nSe ha programado una cita para su mascota. Por favor, revise los detalles en su cuenta.",
                    html = $"<p>Estimado(a) {namesOwner} {lastNameOwner},</p><p>Se ha programado una cita para su mascota. Por favor, revise los detalles en su cuenta.</p>"
                };

               var jsonRequest = JsonSerializer.Serialize(emailMessage);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

                var response = await _httpClient.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    // Agregar mensajes de registro para depurar
                    Console.WriteLine($"Error al enviar el correo: {response.StatusCode}, {responseContent}");
                    throw new HttpRequestException($"Error al enviar el correo: {response.StatusCode}, {responseContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejo de errores
                // Agregar mensajes de registro para depurar
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
                throw new Exception("Error al enviar el correo", ex);
            }
        }
    }
}
