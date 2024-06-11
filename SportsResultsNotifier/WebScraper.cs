using HtmlAgilityPack;

namespace SportsResultsNotifier;

public class WebScraper
{
    private readonly Uri _url;
    private readonly HtmlWeb _web = new();
    public WebScraper(Uri url)
    {  
        _url = url; 
    }

    public string GetData()
    {
        var doc = _web.Load(_url);
        var date = DateTime.Parse(doc.DocumentNode.SelectSingleNode("//div[@id=\"content\"]/h1").InnerHtml.Substring(20));
        if (date < DateTime.Today.AddDays(-1))
        {
            return "No games played on this date";
        }
        else
        {
            var loser = doc.DocumentNode.SelectSingleNode("//tr[@class=\"loser\"]/td/a").InnerHtml;
            var loserScore = doc.DocumentNode.SelectSingleNode("//tr[@class=\"loser\"]/td[@class=\"right\"]").InnerHtml;
            var winner = doc.DocumentNode.SelectSingleNode("//tr[@class=\"winner\"]/td/a").InnerHtml;
            var winnerScore = doc.DocumentNode.SelectSingleNode("//tr[@class=\"winner\"]/td[@class=\"right\"]").InnerHtml;
            return $"{winner} - {winnerScore} : {loser} - {loserScore}";
        }
        
    }

}
