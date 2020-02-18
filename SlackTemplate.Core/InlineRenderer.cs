using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SlackTemplate.Core
{
	public interface IInlineRenderer
	{
		string Render(XElement element);
	}
}
