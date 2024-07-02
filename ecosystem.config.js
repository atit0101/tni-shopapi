module.exports = {
    apps: [
        {
            name: "my-dotnet-app",
            script: "dotnet",
            args: "run ./bin/Debug/net8.0/server.dll",
            cwd: "./",
            watch: true,
            autorestart: true,
            max_memory_restart: "1G",
            env: {
                ASPNETCORE_ENVIRONMENT: "Development"
            },
            env_production: {
                ASPNETCORE_ENVIRONMENT: "Production"
            }
        }
    ]
};
