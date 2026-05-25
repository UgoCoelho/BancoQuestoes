# 📋 Ficha de Acompanhamento e Diagnóstico do Projeto

> **Orientações para a Equipe:** Este documento deve ser preenchido pela equipe para alinhar as expectativas do projeto com os mentores e organizadores. Sejam diretos, honestos e realistas nas respostas.

---

## 🏛️ 1. Identificação da Equipe

- **Nome da Equipe: KnowLi**
- **Nome dos Integrantes e Períodos: Carlos Eduardo De Ataide Pedro - 5º Período
Carlos Eduardo Dos Santos Borges - 5º Período
Gabriel Seixas Pereira Lopes - 5º Período
Laura Ferreira De Souza - 5º Período
Ugo Lamana Coelho - 4º Período
**
- **Link do Repositório (GitHub/GitLab):**
- **Link do Rascunho/Design (Figma/Lovable/Excalidraw): https://www.figma.com/make/QHkPOe8JKIA0wW2Cp3Dunn/Sem-t%C3%ADtulo?p=f&t=x5o0mqkzry1lBZms-0**
---
## 💡 2. O Problema e a Proposta de Valor (O Coração da Ideia)

### 2.1. Qual problema real e específico vocês estão resolvendo?

Estudantes universitários não têm um lugar centralizado e organizado para encontrar materiais de estudo — resumos, listas de exercícios e mapas mentais — compartilhados pelos próprios colegas. O material existe, mas está disperso em grupos de WhatsApp, drives pessoais e pastas sem estrutura, o que dificulta o acesso e o aproveitamento acadêmico.

### 2.2. O diferencial da solução está claro? O que torna a ideia de vocês única?

O **Knowli** organiza o conteúdo por **curso → período → matéria**, replicando exatamente a estrutura curricular que o aluno já conhece. Ao contrário de drives genéricos, todo arquivo é classificado com título, professor, tags e tipo de conteúdo, facilitando a busca. A plataforma também diferencia perfis de acesso (Aluno × Admin), garantindo curadoria do conteúdo sem burocracia.

---

## ⚙️ 3. A Solução na Prática (Como Funciona)

### 3.1. Como a solução funciona para o usuário final?

1. O aluno acessa a plataforma e faz login com sua matrícula e senha.
2. Na tela inicial, seleciona seu **curso** (ex.: Sistemas de Informação).
3. Escolhe o **período** desejado (1º ao 8º).
4. Navega pelas **matérias** daquele período.
5. Dentro de cada matéria, visualiza os arquivos disponíveis (slides, resumos, listas etc.).
6. Faz o **download** direto do material ou acessa os detalhes antes de baixar.
7. Caso queira contribuir, clica em **"Compartilhar Material"** e faz upload do arquivo com título, descrição, professor e tags.

### 3.2. Quais são as principais tecnologias, linguagens ou ferramentas que decidiram usar?

| Camada | Tecnologia |
|---|---|
| **Back-end / Framework** | ASP.NET Core 8 MVC (C#) |
| **ORM / Banco de Dados** | Entity Framework Core 8 + SQL Server (LocalDB) |
| **Front-end** | Razor Views (.cshtml), Bootstrap 5, Bootstrap Icons |
| **Autenticação** | Sessions (ASP.NET Core Session) |
| **Upload de arquivos** | Sistema de arquivos local (`/Storage/Arquivos/`) |
| **Controle de versão** | Git / GitHub |

---

## 👥 4. Gestão e Divisão de Trabalho

### 4.1. Quem está fazendo o quê na equipe?

- **Laura: Front-End, implemtação de Upload e Download de arquivos**
- **Ugo: Estruturação do banco de dados, funções e métodos, criação de MVC, criação do Pitch**
- **Gabriel: Implementação do Login**
- **Carlos Ataide: Controle de acesso (usuário x admin)**
- **Carlos Borges: Criação de tabelas, estruturação do slide de apresentação**

---

## 🛠️ 5. Status Atual do Desenvolvimento (O MVP)

### 5.1. Vocês já começaram o protótipo visual ou o código do MVP? Qual o percentual de conclusão estimado?

- **Status:** (x) Mais da metade pronto

O projeto possui código funcional com telas implementadas, banco de dados migrado e fluxo de navegação completo.

### 5.2. O projeto já funciona em alguma parte? O que já está codificado e operacional?

- ✅ Tela de **login** com autenticação por matrícula e senha
- ✅ Controle de **sessão** e distinção de roles (Admin / Usuário)
- ✅ CRUD completo de **Cursos**, **Matérias**, **Tipos de Arquivo**, **Usuários** e **Arquivos**
- ✅ Navegação **Curso → Período → Matéria → Arquivos** totalmente funcional
- ✅ **Upload** e **download** de arquivos reais (PDF, DOC, imagens etc.)
- ✅ Menu de **Admin** visível apenas para usuários com role Admin
- ✅ Layout responsivo com navbar, avatares e identidade visual **Knowli**
- ✅ Migrations do banco de dados geradas e aplicadas

### 5.3. O que foi ou será "Mockado" (dados fictícios/estáticos)?

- Os **contadores da home** (247 materiais, 1.234 colaboradores, +15 novos essa semana) são valores estáticos fixados no HTML — não são calculados em tempo real a partir do banco.
- O card do curso **Engenharia de Software** na home ainda não possui rota funcional (link aponta para `#`).
- A seção de **comentários** na tela de arquivos por matéria está visualmente implementada mas sem funcionalidade.

### 5.4. O que ainda falta finalizar obrigatoriamente para a entrega?

- [ ] Opção de cadastrar novos usuários no Login
- [ ] Hospedagem (por motivos de conexão, achamos melhor manter a apresentação por slides e a aplicação rodando localmente. )

## 🚧 6. Obstáculos e Pedidos de Ajuda

### 6.1. Qual maior dificuldade da equipe?

> **Descrição:** O principal desafio enfrentado pela equipe foi a utilização do Git/GitHub em um ambiente de desenvolvimento compartilhado, especialmente no controle de versões, organização das alterações realizadas por diferentes integrantes e resolução de conflitos durante o envio e sincronização do código do projeto. 
---

## 🎤 7. Preparação para o Show (O Pitch)

### 7.1. Como será a estratégia de apresentação de vocês na segunda-feira?

> **Descrição:** (Quem vai falar? Vocês pretendem abrir o sistema ao vivo ou vão usar prints/vídeos gravados nas telas dos slides?)
Ugo Lamana Coelho, durante a exposição, serão utilizados prints e vídeos demonstrativos do sistema, com o objetivo de apresentar de forma clara e organizada suas principais funcionalidades, recursos e utilidades, evidenciando como a plataforma atende às necessidades propostas pelo projeto.
