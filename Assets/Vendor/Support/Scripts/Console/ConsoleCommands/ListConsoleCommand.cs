using System.Text;

namespace Support.Console
{
	public sealed class ListConsoleCommand : IConsoleCommand
	{
		public string Name => "list";
		public string Description => "Prints all available console commands' names";
        
		public string Execute(string[] args = null)
		{
			var stringBuilder = new StringBuilder();
            
			foreach (var consoleCommand in Console.Instance.CurrentConsoleCommands)
				stringBuilder.Append($"{consoleCommand.Name} | ");

			return stringBuilder.ToString();
		}
	}
}