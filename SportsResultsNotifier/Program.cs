using SportsResultsNotifier;

WebScraper basketBallScraper = new(new Uri("https://www.basketball-reference.com/boxscores/"));
basketBallScraper.GetData();
