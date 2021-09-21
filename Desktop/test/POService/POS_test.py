from POS import Checkout, checkout

#        | ** Item ** | ** Code ** | ** Offer ** |
#        | -------- | -------- | -------------------------- |
#        | Apple | A | Three for the price of two |
#        | Banana| B | Three for £100             |
#        | Pear  | P | None                       |


#if condition returns True, then nothing happens:

# OFFER ON B
assert checkout(['B', 'A', 'B', 'P', 'B'], {'A': 25, 'B': 40, 'P': 30}) == 155
# OFFER ON A
assert checkout(['A', 'A', 'A', 'P', 'B'], {'A': 25, 'B': 40, 'P': 30}) == 120
# NO OFFER with multiple occurances
assert checkout(['A', 'A', 'P', 'P', 'B'], {'A': 25, 'B': 40, 'P': 30}) == 150
# NO OFFER with one occurance
assert checkout(['A', 'P', 'B'], {'A': 25, 'B': 40, 'P': 30}) == 95
# ALL OFFERS
assert checkout(['B', 'A', 'B', 'P', 'B', 'A', 'A'], {'A': 25, 'B': 40, 'P': 30}) == 180


#############################
# TESTS FOR CHECKOUT CLASS  #
#############################

# OFFER ON B with default prices
c = Checkout()
c.scan('B')
c.scan('A')
c.scan('B')
c.scan('P')
c.scan('B')
assert c.total() == 155

# OFFER ON B with changed prices
c = Checkout({'A': 15, 'B': 60, 'P': 25})
c.clear_list()
c.scan('B')
c.scan('A')
c.scan('B')
c.scan('P')
c.scan('B')
assert c.total() == 140

# OFFER ON B with list scanned
c = Checkout({'A': 15, 'B': 60, 'P': 25})
c.clear_list()
c.scan(['B', 'A', 'B', 'P', 'B'])
assert c.total() == 140

# OFFER ON A with list scanned
c = Checkout({'A': 15, 'B': 60, 'P': 25})
c.clear_list()
c.scan(['A', 'A', 'B', 'P', 'A'])
assert c.total() == 115

# ALL OFFERS with new prices
c = Checkout({'A': 45, 'B': 50, 'P': 40})
c.clear_list()
c.scan(['B', 'A', 'B', 'P', 'B', 'A', 'A'])
assert c.total() == 230