using System;
using System.Collections.Generic;
using System.Threading;
using Gtk;

namespace Sidimsp
{
	public class Processor
	{
		public Processor (int numCores, int numProcesses, int maxCpuBurstTimeRemaining, 
			int minCpuBurstTimeRemaing, int maxIOBurstTimeRemaining, int minIOBurstTimeRemaining,
			int arrivalTimeRange, List<int> queueTypes, List<int> quantums)
		{
			//Set the systemTime to zero
			systemTime = 0;
			
			//Initialize the event handling for all of the cores, there should be one for each Core
			autoEvents = new AutoResetEvent[numCores];
			for(int i = 0; i < numCores; i++){
				autoEvents[i] = new AutoResetEvent(false);	
			}
			
			//Initialize the event handling for the Processor, there should be one for each Processor
			manualEvent = new ManualResetEvent(false);

			_coreList = new List<Core>();
			_numCores = numCores;
			_numProcesses = numProcesses;
			_queueTypes = queueTypes;
			_quantums = quantums;
			_maxCpuBurstTimeRemaining = maxCpuBurstTimeRemaining;
			_minCpuBurstTimeRemaining = minCpuBurstTimeRemaing;
			_maxIOBurstTimeRemaining = maxIOBurstTimeRemaining;
			_minIOBurstTimeRemaining = minIOBurstTimeRemaining;
			_arrivalTimeRange = arrivalTimeRange;
			_coreThreadList = new List<Thread>();
		}
		
		//This will store the number of CPU cycles
		public static int systemTime;
		
		//This will synchronize the Cores with the Processor systemTime, one for each Core
		public static AutoResetEvent[] autoEvents;
		
		//This will tell the Cores to wait until the Processor is done creating processes/load balancing
		public static ManualResetEvent manualEvent;
		
		private List<Core> _coreList;
		private static int _numCores;
		private int _numProcesses;
		private int _maxCpuBurstTimeRemaining;
		private int _minCpuBurstTimeRemaining;
		private int _maxIOBurstTimeRemaining;
		private int _minIOBurstTimeRemaining;
		private int _simulationLength;
		private int _arrivalTimeRange;
		private List<int> _queueTypes;
		private List<int> _quantums;
		private List<Thread> _coreThreadList;
		
		public void StartSimulation() {
			// generate core objects
			Core newCore;
			for(int i = 0; i < _numCores; i++) {
				newCore = new Core(i, _queueTypes, _quantums);
				_coreList.Add( newCore );
			}
			
			int selectedCore = 0;
			int cpuBurstTime;
			int ioBurstTime;
			int pid;
			int priority;
			int arrivalTime = 0;
			int lastArrivalTime;
			string processState = "Waiting";
			Random random = new Random();
			Process p;				// reference to process objects created below
			
			// generate processes
			for(int i = 0; i <_numProcesses; i++) {
				selectedCore = i % _numCores;		// every time a process is generated, assign it to a different core
				cpuBurstTime = random.Next( _minCpuBurstTimeRemaining, _maxCpuBurstTimeRemaining );
				ioBurstTime = random.Next( _minIOBurstTimeRemaining, _maxIOBurstTimeRemaining );
				pid = i;
				priority = random.Next(0,9);
				lastArrivalTime = arrivalTime;
				arrivalTime = lastArrivalTime + random.Next(0, _arrivalTimeRange);
				
				p = new Process(pid, priority, arrivalTime, processState, cpuBurstTime, ioBurstTime);
				
				_coreList[selectedCore].ProcessQueue.AddProcess(p);
			}
			
			// generate core threads
			for(int i = 0; i < _numCores; i++){
				_coreThreadList.Add(new Thread(new ThreadStart(_coreList[i].DoWork)));
			}
			
			int result = 0;
			// run the core threads until finished
			try {
				//Start all of the threads
				for(int i = 0; i < _numCores; i++){
					_coreThreadList[i].Start ();
				}
				
				
				//CODE FOR "AutoResetEvent" HANDLING
				//Increment the System time, and perform load balancing
				for(int i = 0; i < 5; i++){
					//Unblock all of the Core Threads, allowing them to execute
					manualEvent.Set ();
					
					//Wait for all of the Core Threads to execute(Number of handles cannot be greater than 64!)
					WaitHandle.WaitAll (autoEvents);
					
					//Block all of the Core Threads
					manualEvent.Reset ();
					
					//Print out the messages generated by the Cores
					GlobalVar.PrintMessages();
					
					//Increment the systemTime variable
					systemTime++;
					
					//Reset the status of all of the Cores
					SetUnFinished(); 
				}
				
				//Join all of the threads
				for(int i = 0; i < _numCores; i++){
					_coreThreadList[i].Join ();
				}
				
				//At this point all of the threads are complete
				
			}
			catch (ThreadStateException e)
			{
			 Console.WriteLine(e);  // Display text of exception
			 result = 1;            // Result says there was an error
			}
			catch (ThreadInterruptedException e)
			{
			 Console.WriteLine(e);  // This exception means that the thread
			                        // was interrupted during a Wait
			 result = 1;            // Result says there was an error
			}	
			Environment.ExitCode = result;
			
			// message displayed when threads are done
			GlobalVar.OutputMessage("Processor Finished" + Environment.NewLine);
		}
		
		public void LoadBalance() {
			
		}
		
		//This allows the cores to tell Processor that they are done processing
		public static void SetFinished(int numOfFinishedCore){
			if(numOfFinishedCore >= 0){
				autoEvents[numOfFinishedCore].Set();
			}
		}
		
		//This tells the Processor that the cores must do work
		public static void SetUnFinished(){
		for(int i = 0; i < _numCores; i++){
				autoEvents[i] = new AutoResetEvent(false);
			}
		}
		
	}
}

