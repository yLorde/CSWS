# 📚 CSWS --- Controlled Study Windows Shield

**CSWS** é uma aplicação em C# desenvolvida para ajudar você a manter o
foco durante estudos ou tarefas importantes, bloqueando automaticamente
aplicativos distrativos definidos em uma lista personalizada.

Se um aplicativo bloqueado for aberto, o sistema pode fechar o programa
ou bloquear o Windows, evitando procrastinação.

------------------------------------------------------------------------

## ✨ Funcionalidades

✅ Detecta o aplicativo em foco no Windows\
✅ Verifica se ele está na lista de bloqueio\
✅ Bloqueia o acesso automaticamente\
✅ Pode bloquear a estação de trabalho do Windows\
✅ Lista de aplicativos totalmente configurável\
✅ Aplicação leve e simples

------------------------------------------------------------------------

## 🎯 Objetivo

O CSWS foi criado para ajudar estudantes e profissionais a manterem a
produtividade, impedindo o acesso a aplicativos que causam distração
durante períodos de foco.

Exemplos de uso:

-   Bloquear jogos durante estudo\
-   Bloquear redes sociais durante trabalho\
-   Criar sessões de foco profundo\
-   Controle de uso do computador

------------------------------------------------------------------------

## 🧱 Estrutura do Projeto

    CSWS/
    ├── Program.cs
    ├── blockedList.txt
    ├── CSWS.csproj
    ├── CSWS.sln
    └── README.md

### Arquivos importantes

  Arquivo             Descrição
  ------------------- ---------------------------------
  `Program.cs`        Lógica principal da aplicação
  `blockedList.txt`   Lista de aplicativos bloqueados
  `.csproj`           Configuração do projeto
  `.sln`              Solution do Visual Studio

------------------------------------------------------------------------

## ⚙️ Como usar

### 1️⃣ Clone o repositório

``` bash
git clone https://github.com/yLorde/CSWS.git
cd CSWS
```

------------------------------------------------------------------------

### 2️⃣ Configure os aplicativos bloqueados

Abra o arquivo:

    blockedList.txt

Adicione os nomes dos executáveis separados por vírgula.

Exemplo:

    chrome.exe, discord.exe, steam.exe

------------------------------------------------------------------------

### 3️⃣ Compile o projeto

``` bash
dotnet build
```

------------------------------------------------------------------------

### 4️⃣ Execute

``` bash
dotnet run
```

O programa ficará monitorando continuamente o aplicativo em foco.

------------------------------------------------------------------------

## 🔒 Como funciona internamente

O sistema:

1.  Detecta a janela atualmente em foco\
2.  Obtém o nome do aplicativo ativo\
3.  Compara com a lista bloqueada\
4.  Se estiver bloqueado:
    -   bloqueia o Windows ou encerra o processo

------------------------------------------------------------------------

## 🧩 Requisitos

-   Windows\
-   .NET SDK\
-   Permissão para bloquear estação de trabalho

------------------------------------------------------------------------

## 🛠️ Possíveis melhorias futuras

* [ ]   Interface gráfica (GUI)\
* [ ]   Modo whitelist\
* [ ]   Temporizador de foco\
* [ ]   Estatísticas de uso\
* [ ]   Perfis de bloqueio\
* [ ]   Integração com modo Pomodoro\
* [ ]   Serviço do Windows

------------------------------------------------------------------------

## 📄 Licença

Este projeto está licenciado sob a licença MIT.

------------------------------------------------------------------------

## 👨‍💻 Autor

Desenvolvido por **yLorde**
