// See https://aka.ms/new-console-template for more information

using System;

namespace Alunos
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoEscolhida = ObterOpcaoUsuario();

            while(opcaoEscolhida.ToUpper() != "X")
            {
                switch (opcaoEscolhida)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do Aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota desse Aluno:");

                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser numero decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    
                    case "2":
                        foreach(var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                            Console.WriteLine($"ALUNO:{a.Nome} - NOTA {a.Nota} ");
                            }
                        }
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for(int i = 0; i <alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        var mediaGeral = notaTotal / nrAlunos;
                        
                        Enum conceitoGeral;
                        if(mediaGeral<2)
                        {
                            conceitoGeral = Enum.E;
                        }
                        else if(mediaGeral<4)
                        {
                            conceitoGeral = Enum.D;
                        }
                        else if(mediaGeral<6)
                        {
                            conceitoGeral = Enum.C;
                        }
                        else if(mediaGeral<8)
                        {
                            conceitoGeral = Enum.B;
                        }
                        else{
                            conceitoGeral = Enum.A;
                        }

                        Console.WriteLine($"MEDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;
                        default:
                    throw new ArgumentOutOfRangeException();
                }

                opcaoEscolhida = ObterOpcaoUsuario();
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("Escolha a opção desejada: ");
            Console.WriteLine("1 - Inserir novo Aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Calcular média Geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoEscolhida = Console.ReadLine();
            Console.WriteLine("");
            return opcaoEscolhida;
        }
    } 
}


