using Microsoft.Extensions.Configuration;
using SportsResultsNotifier;

ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
IConfiguration configuration = configurationBuilder.AddUserSecrets<Program>().Build();
var emailFrom = configuration.GetSection("EmailInfo")["EmailFrom"];
var password = configuration.GetSection("EmailInfo")["Password"];
var emailTo = configuration.GetSection("EmailInfo")["EmailTo"];

WebScraper basketBallScraper = new(new Uri("https://www.basketball-reference.com/boxscores/"));
var results = basketBallScraper.GetData();

Email myEmailService = new(emailFrom, password, emailTo);
myEmailService.SendEmail($"Basketball Scores for {DateTime.Today.AddDays(-1).ToString("MMMM d")}", results);
