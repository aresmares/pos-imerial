

#        | ** Item ** | ** Code ** | ** Offer ** |
#        | -------- | -------- | -------------------------- |
#        | Apple | A | Three for the price of two |
#        | Banana| B | Three for £100             |
#        | Pear  | P | None                       |

# For example `checkout(['B', 'A', 'B', 'P', 'B'], {'A': 25, 'B': 40, 'P': 30})` should return 155

def checkout(itemCodes, itemPrices):

    offer = {
        'A': {3: itemPrices['A']*2},
        'B': {3: 100}}

    items = set(itemCodes)
    # print(items)

    total = 0
    for i in items:
        occs = itemCodes.count(i)

        if i in offer.keys() and occs in offer[i].keys():
            price = offer[i][occs]
        else:
            price = itemPrices[i] * occs

        # print(i+" : "+str(price))

        total = total + price
    # print(total)
    return total



# CHECKOUT CLASS BASED ON OPTIONAL EXERCISE
class Checkout:

    cost = 0
    itemList = list()

    # init checkout by giving item prices
    def __init__(self, itemPrices={'A': 25, 'B': 40, 'P': 30} ):
        self.itemPrices = itemPrices

        self.offer ={
            'A': {3: itemPrices['A']*2},    # A | Three for the price of two
            'B': {3: 100}}                  # B | Three for £100

    def clear_list(self):
        self.itemList = list()

    # scan singular or multiple items to item list
    def scan(self, itemCode):
        if len(itemCode) == 1:
            self.itemList.append(itemCode)
        else:
            self.itemList.extend(itemCode)

    # Compare item list against offers to see if any are available
    def check_offers(self):
        items = set(self.itemList)

        for i in items:
            occs = self.itemList.count(i)

            if i in self.offer.keys() and occs in self.offer[i].keys():
                price = self.offer[i][occs]
            else:
                price = self.itemPrices[i] * occs
            self.cost = self.cost + price

    # return the total cost of the checkout items including offers
    def total(self):
        self.check_offers()
        return self.cost


