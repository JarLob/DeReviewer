using System.Collections.Generic;
using DeReviewer.Analysis;

namespace DeReviewer.KnowledgeBase
{
    public class Context
    {
        public delegate void PayloadGenerationCompleted(PayloadGenerationMode mode, Payload payload, ref bool interrupt);

        public static Context CreateToTest(string payloadCommand, PayloadGenerationCompleted action = null) =>
            new Context(ExecutionMode.Test, payloadCommand, action);
        
        public static Context CreateToAnalyze() =>
            new Context(ExecutionMode.Analyze, null, null);

        private readonly PayloadGenerationCompleted payloadGenerationCompletedAction;

        private Context(ExecutionMode mode, string command, PayloadGenerationCompleted action)
        {
            Mode = mode;
            PayloadCommand = command;
            payloadGenerationCompletedAction = action;
        }

        public string PayloadCommand { get; }

        public ExecutionMode Mode { get; }
        
        public List<PatternInfo> Patterns { get; } = new List<PatternInfo>();

        internal void RaisePayloadGenerationCompleted(
            PayloadGenerationMode mode, Payload payload, ref bool interrupt)
        {
            payloadGenerationCompletedAction?.Invoke(mode, payload, ref interrupt);
        }
    }
}