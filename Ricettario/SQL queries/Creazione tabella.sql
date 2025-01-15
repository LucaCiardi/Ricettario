CREATE TABLE Ricette
(
    id INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(200) NOT NULL,
    categoria VARCHAR(50) NOT NULL,
    tipoCucina VARCHAR(100),
    tempoPreparazione INT,
    ingredienti VARCHAR(MAX) NOT NULL,
    istruzioni VARCHAR(MAX) NOT NULL,
    difficolta VARCHAR(20)
);