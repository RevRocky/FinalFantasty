"""Handles all aspects of turning cards from mere excel spreadsheet entries and turning them into JSON data for
Final Fantasty as well as creating png-representations of the cards

Author: Rocky Petkov"""

import sys
import os
from card_generation import excelToJson, excelToPNG



def main():
    # Ensure argv is of proper length and that the input file exists
    if (len(sys.argv) != 3):
        print("Correct usage of this script is XLSX to JSON INFILE OUTFILE\nPlease use the correct number of arguments",
              file=sys.stderr)
        exit(1)
    elif not os.path.isfile(sys.argv[1]):
        print("You are trying to call this script on a file which does not exist", file=sys.stderr)
        exit(2)

    print("Updating Database")
    inFile, outFile = sys.argv[1], sys.argv[2]
    cardList = excelToJson.readExcelFile(inFile)        # Reading in the list of cards
    excelToJson.writeJsonFile(cardList, outFile)        # Writing it to JSON
    print("Databases are now upto date!")
    print("Updating Pictures")
    excelToPNG.createPictures(cardList)                 # Updating all of the pictures
    print("Picture Database now updated")
    print("Exiting!")
    exit(0)

main