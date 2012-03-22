using System;
using System.Collections.Generic;

namespace Sidimsp
{
	public abstract class ProcessQueue
	{
		public ProcessQueue ()
		{
			_processesQ = new Queue<Process>();
		}
		
		protected Queue<Process> _processesQ;
		
		public abstract void AddProcess(Process p);
		public abstract void RemoveProcess(Process p);
		public abstract int Run();
		
	}
}

