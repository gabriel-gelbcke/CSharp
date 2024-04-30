public class FolhaPagamento{



    public FolhaPagamento(double valor, double quantidade, double mes, double ano){
        Valor = valor;
        Quantidade = quantidade; 
        Mes = mes;
        Ano = ano;
        Id = Guid.NewGuid().ToString();
    }

    public FolhaPagamento()
    {
        Id = Guid.NewGuid().ToString();
        CalcularSalarioBruto();

        CalcularIrrf();
        
        CalcularInss();

        CalcularFgts();

        CalcularSalarioLiquido();
    }

    public string? Id {get; set;}
    public double? Valor {get; set;}
    public double? Quantidade {get; set;}
    public double? Mes {get; set;}
    public double? Ano {get; set;}
    public double? SalarioBruto {get; set;}
    public double? ImpostoIrrf {get; set;}
    public double? ImpostoInss {get; set;}
    public double? ImpostoFgts {get; set;}
    public double? SalarioLiquido {get; set;}
    public Funcionario? Funcionario {get; set;}
    public string? FuncionarioId {get; set;}

    public void CalcularSalarioBruto() =>
        SalarioBruto = 2000;
        // SalarioBruto = Quantidade * Valor;

    public void CalcularIrrf() {
        if(SalarioBruto <= 1903.98)
            ImpostoIrrf = 0;
        else if(SalarioBruto >= 1903.99)
            ImpostoIrrf = SalarioBruto*0.075 - 142.80;
        else if(SalarioBruto >= 2826.66)
            ImpostoIrrf = SalarioBruto*0.15 - 354.80;
        else if(SalarioBruto >= 3751.06)
            ImpostoIrrf = SalarioBruto*0.225 - 636.13;
        else
            ImpostoIrrf = SalarioBruto*0.275 - 869.36;
    }

    public void CalcularInss(){
        if(SalarioBruto <= 1693.72){
            ImpostoInss = SalarioBruto*0.08;
        }else if(SalarioBruto >= 1693.73 && SalarioBruto <= 2822.90){
            ImpostoInss = SalarioBruto*0.9;
        }else if(SalarioBruto >= 2822.91 && SalarioBruto <= 5645.81){
            ImpostoInss = SalarioBruto*0.11;
        }else{
            ImpostoInss = 621.03;
        }
    }

    public void CalcularFgts(){
        ImpostoFgts = SalarioBruto*0.08;
    }

    public void CalcularSalarioLiquido(){
        SalarioLiquido = SalarioBruto - ImpostoIrrf - ImpostoInss;
    }
        
}