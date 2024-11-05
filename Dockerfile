# Etapa única: Build e Runtime usando SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS final
WORKDIR /app

# Instala a ferramenta dotnet-ef
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Copia o arquivo de solução e os arquivos de projeto
COPY SistemaNacoes.sln ./
COPY SistemaNacoes.API/SistemaNacoes.API.csproj SistemaNacoes.API/
COPY SistemaNacoes.Application/SistemaNacoes.Application.csproj SistemaNacoes.Application/
COPY SistemaNacoes.Domain/SistemaNacoes.Domain.csproj SistemaNacoes.Domain/
COPY SistemaNacoes.Infra/SistemaNacoes.Infra.csproj SistemaNacoes.Infra/
COPY SistemaNacoes.IoC/SistemaNacoes.IoC.csproj SistemaNacoes.IoC/
COPY SistemaNacoes.Shared/SistemaNacoes.Shared.csproj SistemaNacoes.Shared/

# Restaura as dependências
RUN dotnet restore

# Copia todos os arquivos restantes do projeto
COPY . .

# Compila a aplicação
RUN dotnet publish SistemaNacoes.API/SistemaNacoes.API.csproj -c Release -o /app/out

# Muda para a pasta de saída publicada
WORKDIR /app/out

# Executa as migrations e a aplicação
ENTRYPOINT ["sh", "-c", "dotnet ef database update --project /app/SistemaNacoes.Infra --startup-project /app/SistemaNacoes.API && dotnet SistemaNacoes.API.dll"]
