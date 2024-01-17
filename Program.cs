int N = 5;
tp_no[] semTratamento = new tp_no[N];
tp_no[] linear = new tp_no[N];
tp_no[] encadeado = new tp_no[N];

int Hash (int chave)
{
    return chave % N;
}

void Insere_sem_tratamento(int chave, int whats, string? nome)
{
    int pos = Hash(chave);

    semTratamento[pos] = new tp_no
    {
        idade = chave,
        nome = nome,
        whats = whats
    };
}

void Busca_sem_tratamento(int chave)
{
    int pos = Hash(chave);

    if (semTratamento[pos] == null)
        System.Console.WriteLine("\nNão há registros com a idade informada!");
    else
    {
        System.Console.WriteLine("\nNome: " + semTratamento[pos].nome);
        System.Console.WriteLine("\nAlterar nome: ");
        semTratamento[pos].nome = Console.ReadLine();
        System.Console.WriteLine("\nAlterar whats: ");
        semTratamento[pos].whats = Convert.ToInt32(Console.ReadLine());
    }
}

void Relatar_sem_tratamento()
{
    if (semTratamento == null)
        System.Console.WriteLine("\nNão há registros cadastrados!");
    else
    {
        for (int i = 0; i < semTratamento.Length; i++)
        {
            if (semTratamento[i] != null)
            {
                System.Console.WriteLine("\nNome: " + semTratamento[i].nome);
                System.Console.WriteLine("Idade: " + semTratamento[i].idade);
                System.Console.WriteLine("Whats: " + semTratamento[i].whats);
            }
        }
    }
}

void Insere_linear(int chave, int whatsLinear, string? nomeLinear)
{
    int pos = Hash(chave);

    while (linear[pos] != null)
    {
        pos++;
        pos %= N;
    }

    linear[pos] = new tp_no
    {
        nome = nomeLinear,
        whats = whatsLinear,
        idade = chave
    };
}

void Busca_linear(int chave)
{
    int pos = Hash(chave);

    if (linear[pos] == null)
        System.Console.WriteLine("\nNão há registros com a idade informada!");
    else
    {

        int contador = 0;
        while (contador < linear.Length)
        {

            if (chave == linear[pos].idade)
            {
                System.Console.WriteLine("\nNome: " + linear[pos].nome);
                System.Console.WriteLine("\nAlterar nome: ");
                linear[pos].nome = Console.ReadLine();
                System.Console.WriteLine("\nAlterar whats: ");
                linear[pos].whats = Convert.ToInt32(Console.ReadLine());
                return;
            }
            else
            {
                contador++;
                pos++;
                pos %= N;
            }
        }
        System.Console.WriteLine("\nNão há registros com a idade informada!");
    }
}

void Relatar_linear()
{
    if (linear == null)
        System.Console.WriteLine("\nNão há registros cadastrados!");
    else
    {
        for (int i = 0; i < linear.Length; i++)
        {
            if (linear[i] != null)
            {
                System.Console.WriteLine("\nNome: " + linear[i].nome);
                System.Console.WriteLine("Idade: " + linear[i].idade);
                System.Console.WriteLine("Whats: " + linear[i].whats);
            }
        }
    }
}

void Insere_encadeado(int chave, int whatsEncadeado, string? nomeEncadeado)
{
    int pos = Hash(chave);
    tp_no no = new tp_no
    {
        nome = nomeEncadeado,
        idade = chave,
        whats = whatsEncadeado
    };

    if (encadeado[pos] != null)
        no.prox = encadeado[pos];

    encadeado[pos] = no;
    
}

void Busca_encadeado(int chave)
{
    int pos = Hash(chave);

    if (encadeado[pos] == null)
        System.Console.WriteLine("\nNão há registros com a idade informada!");
    else
    {
        int contador = 0;
        tp_no? atual = encadeado[pos];

        while (atual != null)
        {

            if (chave == atual.idade)
            {
                contador ++;
                System.Console.WriteLine("\nNome: " + atual.nome);
                System.Console.WriteLine("\nAlterar nome: ");
                atual.nome = Console.ReadLine();
                System.Console.WriteLine("\nAlterar whats: ");
                atual.whats = Convert.ToInt32(Console.ReadLine());
            }
            atual = atual.prox;
        }

        if (contador == 0)
            System.Console.WriteLine("\nNão há registros com a idade informada!");
        else
        {
            System.Console.WriteLine("\n" + contador + " registro(s) alterado(s)!");
        }
    }
    
}

void Relatar_encadeado()
{
    if (encadeado == null)
        System.Console.WriteLine("\nNão há registros cadastrados!");
    else
    {
        for (int i= 0; i < encadeado.Length; i++)
        {
            tp_no? atual = encadeado[i];

            while (atual != null)
            {
                System.Console.WriteLine("\nNome: " + atual.nome);
                System.Console.WriteLine("Idade: " + atual.idade);
                System.Console.WriteLine("Whats: " + atual.whats);
                atual = atual.prox;
            }
        }
    }
}

int whats, idade;
string? nome;
int op = 0;

while (op != 4)
{
    System.Console.WriteLine("\nMENU\n");
    System.Console.WriteLine("1 - Sem tratamento");
    System.Console.WriteLine("2 - Tratamento Linear");
    System.Console.WriteLine("3 - Tratamento com lista encadeada");
    System.Console.WriteLine("4 - Sair");
    op = Convert.ToInt32(Console.ReadLine());

    int op2 = 0;

    if (op != 4)
    {
        System.Console.WriteLine("\nMENU SECUNDÁRIO\n");
        System.Console.WriteLine("1 - Inserir");
        System.Console.WriteLine("2 - Alterar");
        System.Console.WriteLine("3 - Relatar");
        System.Console.WriteLine("4 - Sair");
        op2 = Convert.ToInt32(Console.ReadLine());

        if (op2 == 1)
        {
            System.Console.WriteLine("\nInforme a idade: ");
            idade = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Informe o nome: ");
            nome = Console.ReadLine();
            System.Console.WriteLine("Informe o whats: ");
            whats = Convert.ToInt32(Console.ReadLine());

            if (op == 1)
                Insere_sem_tratamento(idade, whats, nome);
            else if (op == 2)
                Insere_linear(idade, whats, nome);
            else if (op == 3)
                Insere_encadeado(idade, whats, nome);
        }

        if (op2 == 2)
        {
            System.Console.WriteLine("\nInforme a idade a ser pesquisada: ");
            int chave = Convert.ToInt32(Console.ReadLine());

            if (op == 1)
                Busca_sem_tratamento(chave);
            else if (op == 2)
                Busca_linear(chave);
            else if (op == 3)
                Busca_encadeado(chave);
        }

        if (op2 == 3)
        {
            if (op == 1)
                Relatar_sem_tratamento();
            else if (op == 2)
                Relatar_linear();
            else if (op == 3)
                Relatar_encadeado();
        }
    }
}

class tp_no
{
    public int idade;
    public string? nome;
    public int whats;
    public tp_no? prox;
}