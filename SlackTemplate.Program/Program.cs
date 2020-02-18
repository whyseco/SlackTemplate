using SlackTemplate;
using System;
using System.Xml.Linq;

namespace LiquidSlackRenderer
{
	class Program
	{
		static void Main(string[] args)
		{
			var tmplRenderer = new SlackLibraryTemplateRenderer();

			var codeBlock = tmplRenderer.Render("<section>Hello <b>{{ name }}</b></section>", new { Name = "Yann" });

			Console.WriteLine(codeBlock.Layouts.Count);
		}
	}
}
