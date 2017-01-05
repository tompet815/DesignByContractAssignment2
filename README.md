# Design by Contract Assignment 2
  
## Requirements
The bank should use double entry bookkeeping. The balamce in Account is a calculated field, and should always reflect the sum of movement amounts.

## Contracts
* Making sure that moving amount should be more than 0.
* Making sure that the sum of the all customers' Debit amounts substracts the sum of the all customers' credits amounts is zero.
* Making sure that the balance of crediting account will not be less than 0
