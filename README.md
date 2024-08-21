# Sistema de Agendamentos de Voluntários

Este projeto é um sistema de agendamentos para voluntários vinculados a ministérios, desenvolvido para facilitar a gestão de atividades e horários dos voluntários dentro da igreja Nações. O sistema permite que líderes ou coordenadores de ministérios gerenciem voluntários, ministérios, atividades e agendamentos de forma eficiente.

## Entidades Principais

### Usuário

- **Descrição**: Líder ou coordenador do(s) ministério(s).
- **Funções**:
  - Cria, edita e remove voluntários e ministérios.
  - Realiza agendamentos de voluntários.
  - Possui acesso ao sistema.
- **Principais Campos**:
  - Nome
  - Email
  - Senha
  - Ministérios vinculados (O líder do ministério "Jovem" não pode acessar informações do ministério "Pessoal").

### Voluntário

- **Descrição**: Participantes dos ministérios.
- **Funções**:
  - Pode estar vinculado a mais de um ministério.
  - Informa datas indisponíveis através de um link enviado por um usuário do sistema.
  - Não possui acesso direto ao sistema.
- **Principais Campos**:
  - Nome
  - Email
  - CPF
  - Data de nascimento
  - Ministérios vinculados

### Ministério

- **Descrição**: Departamentos da igreja (Ex.: Ministério de Jovens, Ministério da Saúde).
- **Funções**:
  - Pode estar vinculado a mais de um voluntário.
- **Principais Campos**:
  - Nome
  - Descrição
  - Cor
  - Atividades
  - Voluntários e usuários vinculados

### Atividade

- **Descrição**: Ação que o voluntário irá realizar dentro do ministério (Ex.: Ministério Jovem, atividade "Passar a lição da escola sabatina").
- **Funções**:
  - Uma atividade pertence somente a um ministério.
- **Principais Campos**:
  - Nome

### Grupo

- **Descrição**: Grupo de voluntários (Ex.: Famílias, casais, amigos).
- **Funções**:
  - Possui mais de um voluntário.
  - Um voluntário pode ter apenas um grupo.
- **Principais Campos**:
  - Nome
  - Voluntários

## Regras de Agendamento

- Os voluntários são agendados selecionando um ministério e atividade.
- Um voluntário pode estar agendado somente em uma agenda no dia todo.
- Um voluntário não pode estar agendado em mais de um ministério na mesma agenda, ou em outra agenda do mesmo dia.
- É possível definir períodos onde um voluntário estará ausente; nesse período ele não pode ser agendado.
- É possível agendar um grupo de voluntários de uma única vez (todos precisam ter o ministério vinculado).
- Não é possível abrir horários retroativos.

## Geração Automática de Escalas

Este sistema também possui a funcionalidade de gerar escalas automaticamente.

- **Processo de Geração**:
  - A geração de escalas ocorre por ministério. O usuário seleciona um ministério e o sistema lista todas as atividades desse ministério.
  - Para cada atividade, o usuário define o número de voluntários necessários.
  - O sistema calcula e realiza a inserção automática dos voluntários, assegurando que cada voluntário esteja vinculado ao ministério selecionado.
  - Caso um voluntário pertença a um grupo (como uma família), o sistema tentará agendar todos os membros do grupo na mesma atividade. Se isso não for possível, o voluntário e seu grupo serão descartados da escala, e o sistema buscará outro voluntário que atenda aos requisitos.

## Demonstração

Veja uma demonstração do processo de geração automática de escalas no vídeo abaixo:

[![Demonstração do Processo de Escala](https://cdn.loom.com/sessions/thumbnails/966e77b4523c47d2a2b97bf004280a4f-with-play.gif)](https://www.loom.com/share/966e77b4523c47d2a2b97bf004280a4f)
