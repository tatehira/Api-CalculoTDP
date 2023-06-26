# CalculoTDP Backend

## Descrição

Este repositório contém o código do backend para o projeto CalculoTDP, que está relacionado ao cálculo de TDP (Thermal Design Power) de componentes desktop. O TDP é uma medida da quantidade de energia térmica que um dispositivo eletrônico produz quando está em pleno funcionamento. O cálculo do TDP é essencial para garantir que os componentes eletrônicos estejam operando dentro de limites seguros de temperatura.

## Frontend

O frontend que correspondente a este backend pode ser encontrado no seguinte repositório: [Front-CalculoTDP](https://github.com/tatehira/Front-CalculoTDP). O frontend é responsável por fornecer a interface gráfica para que os usuários possam inserir os dados necessários para o cálculo do TDP, e em seguida, enviar esses dados para o backend realizar os cálculos.

## Por que calcular o TDP?

O cálculo do TDP é uma etapa importante no projeto e na escolha de componentes eletrônicos. Aqui estão algumas razões pelas quais é importante realizar o cálculo do TDP:

1. **Segurança térmica:** O TDP está diretamente relacionado à dissipação de calor de um componente. Ao conhecer o TDP de um dispositivo, é possível dimensionar corretamente o sistema de resfriamento necessário para manter o componente dentro de uma faixa de temperatura segura.

2. **Projeto de sistemas de refrigeração:** Ao calcular o TDP, é possível projetar sistemas de refrigeração adequados, como dissipadores de calor, ventoinhas ou sistemas de refrigeração líquida, para garantir que os componentes eletrônicos não superaqueçam e causem falhas prematuras.

3. **Eficiência energética:** O cálculo do TDP permite estimar a quantidade de energia elétrica necessária para alimentar um componente eletrônico e, assim, otimizar a eficiência energética do sistema.

4. **Seleção e compatibilidade de componentes:** Conhecer o TDP de um componente é fundamental para selecionar e combinar componentes eletrônicos de forma adequada, evitando sobrecargas térmicas e garantindo a compatibilidade entre eles.

Não deixe de conferir o frontend correspondente a este backend para realizar os cálculos de TDP de forma intuitiva e fácil de usar. Clique [aqui](https://github.com/tatehira/Front-CalculoTDP) para acessar o frontend.

## API

A API fornecida pelo backend retorna um JSON com as seguintes propriedades:

```json
{
  "Cpu": "Processador 1",
  "Gpu": "Placa de vídeo 1",
  "Ram": "Memória RAM 1",
  "HDD": "Armazenamento HDD 1",
  "SSD": "Armazenamento SSD 1",
  "Motherboard": "Placa-mãe 1",
  "TdpDefault": 0,
  "TdpTotal": 100
}
