namespace SumoX.Report.Engine
{
    public class CrossDelegate
    {
        public delegate string GetContent(string ContentSource);
        public GetContent SubReportGetContent=null;
    }
}
