DROP TABLE alunos;
CREATE TABLE alunos(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	nome VARCHAR(150) NOT NULL,
	codigo_matricula VARCHAR(100),
	nota_1 FLOAT NOT NULL,
	nota_2 FLOAT NOT NULL,
	nota_3 FLOAT NOT NULL,
	frequencia TINYINT,
	faltas TINYINT NOT NULL,
);

INSERT INTO alunos(nome, codigo_matricula, nota_1, nota_2, nota_3, frequencia, faltas) VALUES
('Morramad', 986532147, 10, 10, 9, 74, 5),
('Vendedor de algodão doce', 745896541, 8, 10, 4, 100, 0),
('Rubinho', 145879632, 7, 8, 9, 72, 0),
('Alabah', 458975632, 6, 5, 8, 90, 0),
('Transformation', 147896325, 6, 7, 4, 25, 50);