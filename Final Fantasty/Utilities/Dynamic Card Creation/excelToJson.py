import simplejson as json
from collections import OrderedDict
import xlrd
import sys
import os

"""This module reads an .xlsx file and converts each entry (row wise) into a JSON object
storing each object in a database.

ASSUMES that all data is seperated by columns

(CC) 2017 Rocky Raccoon"""

# TODO Ensure it works propely for each kind of card

# Reads an excel file into a propely formatted list of dictionaries
# TODO Make more general in any case
def readExcelFile(inFile):
	# Opening our excel file
	workBook = xlrd.open_workbook(inFile)
	workSheet = workBook.sheet_by_index(0)
	cardList = []						# A list of dictionaries. One entry for each card

	# Iterating through our spreadsheet
	for row in range(1, workSheet.nrows):
		card = OrderedDict()
		rowValues = workSheet.row_values(row)
		card["Type"] = rowValues[0]
		card["Name"] = rowValues[1]
		card["Description"] = rowValues[2]
		card["Stats"] = (rowValues[3], rowValues[4], rowValues[5], rowValues[6], rowValues[7], rowValues[8])	 # Sweet, Sour, Bitter, Spicy, Acidic, Umami (Not final)
		card["Mechanics"] = (rowValues[9], rowValues[10])	# Stored as a two-tuple
		card["Tags"] = rowValues[11]
		cardList.append(card)

	return cardList

# Writes the dictionaries stored in "listofDicts" to the specified
# output file as a properly formatted json file
def writeJsonFile(listofDicts,outFile):
	jsonData = json.dumps(listofDicts)

	#write to file
	with open(outFile, 'w') as out:
		out.write(jsonData)



def main():
	# Ensure argv is of proper length and that the input file exists
	if (len(sys.argv) != 3):
		print("Correct usage of this script is XLSX to JSON INFILE OUTFILE\nPlease use the correct number of arguments", file=sys.stderr)
		exit(1)
	elif not os.path.isfile(sys.argv[1]):
		print("You are trying th call this script on a file which does not exist", file=sys.stderr)
		exit(2)

	print ("Updating Database")
	inFile, outFile = sys.argv[1], sys.argv[2]
	cardList = readExcelFile(inFile)
	writeJsonFile(cardList, outFile)
	print("Databases are now upto date!")
	exit(0)

main()