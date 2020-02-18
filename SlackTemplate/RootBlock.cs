using SlackLibrary.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackTemplate
{
	public class RootBlock
	{
		public RootBlock()
		{
			this.Layouts = new List<BlockBase>();
		}

		public IList<BlockBase> Layouts { get; protected set; }
	}
}
