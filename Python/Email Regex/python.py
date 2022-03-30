### RegEx practice
import re

txt = "sunnygupta@emiil.net"
emailRegex = ".+@.+\.com|net"
x = re.search(emailRegex, txt)

if x:
    print("Valid email")
else:
    print("Invalid email")
