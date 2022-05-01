using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.FileSystemGlobbing;
using System.ComponentModel.DataAnnotations;

namespace GitHubAction;

[Command(Description = "Finds matching files.")]
public class AppCommand
{
    [Required]
    [Option(Description = "Required. File pattern.")]
    public string Pattern { get; set; } = null!;

    public int OnExecute(IConsole console)
    {
        try
        {
            var matcher = new Matcher();
            matcher.AddInclude(this.Pattern);

            var result = matcher.GetResultsInFullPath(Environment.CurrentDirectory);
            var filesString = string.Join(
                "<br>",
                result.Select(path => path.Replace(Environment.CurrentDirectory, string.Empty)));

            console.WriteLine($"::set-output name=files::{filesString}");
            return 0;
        }
        catch (Exception ex)
        {
            console.WriteLine(ex);
            return 1;
        }
    }
}
