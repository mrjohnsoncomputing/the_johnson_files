def readfile(filename):
  with open(filename, "r") as file:
    data = file.read()
  return data
  
text = readfile("the_manuscript.txt")
MY_LETTER = input("What is your letter?")
count = 0
for letter in text:
  if letter = MY LETTER:
    count += 1
print(count)
