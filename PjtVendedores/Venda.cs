namespace PjtVendedores;

public  class Venda{
   private int qtde;
   private double preco;

   public double valorMedio(){
      return preco / qtde;
   }
}
