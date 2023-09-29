using System.Net;
using System.Net.Mail;

public class Mail{
    private IConfiguration _configuration;

    public Mail(IConfiguration configuration){
        _configuration = configuration;
    }
    public void SendMailProjectCharter(SendMailProjectCharterDto mail){
        string from = _configuration["Mail:User"];
        string password = _configuration["Mail:Password"];
        string host = _configuration["Mail:Host"];
        int port = int.Parse(_configuration["Mail:Port"]);

        MailMessage message = new(from,mail.To)
        {
            Body = "<strong>Oiiiii</strong>",
            Subject = "Termo de abertura aguardando homologação"
        };

        SmtpClient client = new(host, port)
        {
            Credentials = new NetworkCredential(from, password),
            EnableSsl = true,
        };

        client.Send(message);
    }
}