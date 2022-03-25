class BankAccount:
    balance = 0
    int_rate = 0.01
    def __init__(self, int_rate, balance): 
        self.balance = balance
        self.int_rate = int_rate

    def deposit(self, amount):
        self.balance += amount
        return self

    def withdraw(self, amount):
        if(amount > self.balance):
            print("Insufficient funds: Charging a $5 fee")
            self.balance -= 5
        else:
            self.balance -= amount
        return self

    def display_account_info(self):
        print("Balance: $" + str(self.balance))
        return self
        
    def yield_interest(self):
        if(self.balance > 0):
            self.balance *= 1 + self.int_rate
        return self


accountOne = BankAccount(0.01, 20)
accountTwo = BankAccount(0.01, 50)

accountOne.deposit(10).deposit(12).deposit(200).withdraw(90).yield_interest().display_account_info()
accountTwo.deposit(400).deposit(15).withdraw(10).withdraw(200).withdraw(5).withdraw(20).yield_interest().display_account_info()