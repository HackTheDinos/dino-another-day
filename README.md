# dino-another-day
A tool for visualizing paleo data in virtual reality.

### The Issue
How do paleontologists know where to dig? Three criteria define the choice of location for exploration:
- The rock must be sedimentary.
- The sedimentary rock must be exposed on the earth's surface.
- The sedimentary layer must be between 250 - 65 million years old

It also should not have been explored too much.

**The question is:**

>What additional data could be pulled in 
>to support paleontologists in justifying 
>the worthiness of exploratory digs in different locations
>to potential grantors,
>thereby supporting their grant-writing process? 

**Example question:** The Gobi Desert is a well-known and high-yielding paleontolological site from the late Cretaceous period. The Hell Creek Formation in Montana, US is also well-investigated, sits at 107 Long, 47 30" Lat, fairly similarly to the Gobi site, and is also late Cretaceous. Do they also share historical climatological or other geological similarities?

**2nd sample question:** Both the Gobi desert and Hell Creek formations have had many digs. However, has either site experienced a recent weather (or other) related event that has perhaps exposed a new layer of sedimentary rock that could be explored for new fossils?

### The Data

All data is taken from [The PaleoBiology Database](https://paleobiodb.org/#/).

[This listing contains](https://docs.google.com/spreadsheets/d/1W6PcwoVrNzrrpLN2OESVnD8dbAFxIDg5xjrhO_9ZR0M/edit?usp=sharing) all the fields/codes for accessing data related to these topics:
* Lists of fossil collections API
* Geographic clusters of fossil collections API
* Lists of geological strata API
* Geographic clusters of fossil collections API
* Stratigraphy of fossil occurrences API
* Fossil diversity over time (full computation) API Calls
* Taxonomy of fossil occurrences API
* Client configuration API

### Solution == NextDig

### How It Works

Please see the presentation link in the Wiki.

### What's Next

Currently, the app pulls data from the PaleoBioDB and displays the number of fossils found within 5 degrees on the globe for any two locations in a bar graph. Future work could expand upon the representation of the data and pull in additional data from other collections on related issues:

* historical and recent weather history
* geological formations
* strata information
* historical climate/environmental data
