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


class User(BankAccount):
    balance = 0
    int_rate = 0.01
    def __init__(self, int_rate, balance):
        self.balance = balance
        self.int_rate = int_rate

    def make_deposit(self, amount):
        self.deposit(amount)

    def make_withdrawal(self, amount):
        self.withdraw(amount)

    def display_user_balance(self):
        self.display_account_info()





