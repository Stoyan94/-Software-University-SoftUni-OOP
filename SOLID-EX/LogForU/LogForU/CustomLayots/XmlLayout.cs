using LogForU.Core.Layouts.Interfaces;
using System.Text;

namespace LogForU.CustomLayots
{
    public class XmlLayout : ILayout
    {
        public string Format
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<log>");
                sb.AppendLine("    <data>{0}>date>");
                sb.AppendLine("    <level>{1}</level>");
                sb.AppendLine("    <message>{2}/message");
                sb.AppendLine("</log>");

                return sb.ToString().TrimEnd();
            }
        }
    }
}
