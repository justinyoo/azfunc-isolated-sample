# Azure Functions Isolated Worker Sample

## Getting Started

1. If you want to run the .NET 6 function app, install the .NET 6 SDK first by running the script:

    ```bash
    wget https://dot.net/v1/dotnet-install.sh -O ~/dotnet-install.sh
    chmod +x ~/dotnet-install.sh
    ~/dotnet-install.sh --version latest
    ```

1. Open `local.settings.json` on both apps and replace `{{CODESPACE_NAME}}` with your GitHub Codespace instance name. You can check your codespace instance name by running the command:

    ```bash
    echo $CODESPACE_NAME
    ```

1. Restore NuGet packages and build both apps

    ```bash
    dotnet restore && dotnet build
    ```

1. Install Azure Functions Core Tools

    ```bash
    npm install -g azure-functions-core-tools@4 --unsafe-perm true
    ```

1. Run the function app to confirm

    ```bash
    # For .NET 6
    cd FunctionAppNet6
    func start

    # For .NET 7
    cd FunctionAppNet7
    func start
    ```
