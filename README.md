# EverisChallenge
Criação de api com base no desafio abaixo:

Proposta
Crie um aplicativo backend que irá expor uma API RESTful de SingUp/SignIn e
Consulta de Usuário.
Todos os endpoints devem somente aceitar e somente enviar JSONs. O servidor
deverá retornar JSON para os casos de endpoint não encontrado também.
O aplicativo deverá persistir os dados (ver detalhes em requisitos).
Todas as respostas de erro devem retornar o objeto:
{
 "mensagem": "mensagem de erro"
}
Prazo
• 3 dias corridos.
SignUp
• Endpoint: /usuarios/signup
• Este endpoint deverá receber um usuário com os seguintes campos: nome,
email, senha e uma lista de objetos telefone. Seguem os modelos:
{
 "nome": "string",
 "email": "string",
 "senha": "senha",
 "telefones": [
 {
 "numero": "123456789",
 "ddd": "11"
 }
}
Usar status codes de acordo
• Em caso de sucesso irá retornar a seguinte estrutura:
{
 "id": "string",
 "nome": "string",
 "email": "string",
 "data_criacao": "string",
 "data_atualizacao": "string",
 "ultimo_login": "string",
 "token": "string"
}
• id: id do usuário (pode ser o próprio gerado pelo banco, porém seria
interessante se fosse um GUID)
• nome: nome do usuário
• email: email do usuário
• data_criacao: data da criação do usuário
• data_atualizacao: data da última atualização do usuário
• ultimo_login: data do último login (no caso da criação, será a mesma que a
criação)
• token: token de acesso da API (pode ser um GUID ou um JWT)
• Caso o e-mail já exista, deverá retornar erro com a mensagem "E-mail já
existente".
• O token deverá ser persistido junto com o usuário
Sign in
• Endpoint: /usuarios/signin
• Este endpoint irá receber um objeto com e-mail e senha.
{
 "email": "string",
 "senha": "string"
}
• Caso o e-mail exista e a senha seja a mesma que a senha persistida:
o gerar um novo token
o alterar a data do último login
o persistir no banco de dados
o retornar o mesmo objeto retornado no endpoint do SignUp.
• Caso o e-mail não exista, retornar erro com status apropriado mais a mensagem
"Usuário e/ou senha inválidos"
• Caso o e-mail exista mas a senha não bata, retornar o status apropriado 401
mais a mensagem "Usuário e/ou senha inválidos”
Consultar Usuário
• Endpoint: /usuario/{id_usuario}
• Chamadas para este endpoint devem conter um header na requisição de
Authentication com o valor "Bearer {token}" onde {token} é o valor do token
passado na criação ou sign in de um usuário.
• Caso o token não exista, retornar erro com status apropriado com a mensagem
"Não autorizado".
• Caso o token exista, buscar o usuário pelo user_id passado no path e comparar
se o token no modelo é igual ao token passado no header.
• Caso não seja o mesmo token, retornar erro com status apropriado e mensagem
"Não autorizado"
• Caso seja o mesmo token, verificar se o último login foi a MENOS que 30
minutos atrás.
• Caso não seja a MENOS que 30 minutos atrás, retornar erro com status
apropriado com mensagem "Sessão inválida".
• Caso tudo esteja ok, retornar o usuário.
Requisitos
• Persistência de dados (Qualquer banco de dados. Pode ser relacional, NoSQL,
InMemory, etc)
• API usando Asp.Net Core
Requisitos desejáveis
• JWT como token
• Testes unitários com xUnit ou nUnit
• Criptografia não reversível (hash) na senha e no token
• LiteDB ou MongoDB como banco de dados
Submissão
• O desafio deve ser entregue pelo GitHub
