using GitHubAction;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder()
    .RunCommandLineApplicationAsync<AppCommand>(args);
