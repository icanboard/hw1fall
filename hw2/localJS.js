//This function calculates miles/mpg * ppg and creating a table displaying relevant information
//accordingly. Uses mpg, ppg, and tripMiles.
function calculatePrices()
{
	var outputDiv = $('#tableOutput');
	var mpg = $('#mpg').val();
	var ppg = $('#ppg').val();  
	var tripMiles = $('#tripMiles').val();
	var outputString = '';
	var mpgTemp = mpg;
	var tripMilesTemp = tripMiles;
	if(ppg[0] == '$')
    {
        ppg = ppg.split('$');
        ppg = parseFloat(ppg[1]);
    }
    
    if(validateData(mpg, ppg, tripMiles) == 1)
    {
        return(1);
    }
    
	//start building the table
    outputString = '<br><table>';
	
	//build table
	for(var i=0; i<5; i++)
	{        
		//add title and build headers first
		if(i==0)
		{
			//k-1 number of headers headers
			for(var k=0; k<11; k++)
			{
				//add header and build tr before adding th and make an empty th for k=0
				if(k==0)
				{
					outputString += '<h2>Cost Per Trip</h2><tr><th></th>';
				}
				else
				{
					//add th and data
					outputString += '<th>' + tripMilesTemp + ' miles</th>';
					
					//increment tripMiles by 1
					tripMilesTemp++;
				}
				
				//close tr on final pass
				if(k==10)	
				{
					outputString += '</tr>';
				}
			}
		}
		
		//reset tripMilesTemp
		tripMilesTemp = tripMiles;
		
		//build content of table
		for(var j=0; j<11; j++)
		{
			//build tr on first pass
			if(j==0)
			{
				outputString += '<tr><th>' + parseInt(mpgTemp) + ' mpg</th>';
			}
			else
			{
				//add td and data. ensure the data is a float with parseFloat and 2 decimals with .toFixed(2)
				outputString += '<td>$' + parseFloat(tripMilesTemp/mpgTemp * ppg).toFixed(2) + '</td>';
				
				//increment tripMilesTemp
				tripMilesTemp++;
			}
			
			//close tr on final pass
			if(j==10)
			{
				outputString += '</tr>';
				
				//increment mpgTemp by 2; increment in final pass
				mpgTemp = parseInt(mpgTemp) + 2;
			}
		}
	}
	
	//close the table
	outputString += '</table>';
	
	//insert the new table into the htlm page
	outputDiv.html(outputString);
}

function validateData(mpg, ppg, tripMiles)
{
    //validate empty strings
	if(mpg == '' || ppg == '$' || ppg == '' || tripMiles == '')
	{
		alert("You must use a valid value for Price per Gallon, Miles per Gallon, and Miles Driven.");
        return(1);
	}
    
    //validate inputs are numbers
    if(isNaN(parseFloat(ppg)))
    {
        alert('Price per Gallon must be a number.')
        return(1);
    }
    if(isNaN(parseFloat(mpg)))
    {
        alert('Miles per Gallon must be a number.')
        return(1);
    }
    if(isNaN(parseFloat(tripMiles)))
    {
        alert('Miles Driven must be a number.')
        return(1);
    }
	
	//validate ppg is valid
	if(ppg<=0)
	{
		alert("Free gas? Hook me up!");
        return(1);
	}
	if(ppg>'20')
	{
		alert("Is that a realistic price for gas? I hope not!");
        return(1);
	}
	
	//validate mpg is valid
	if(mpg<5)
	{
		alert("Your car can't possible have that bad mpg! It has to be 5 or higher.");
        return(1);
	}	
	if(mpg>100)
	{
		alert("I want to buy your car. It's mpg is awesome!");
        return(1);
	}
	
	//validate tripMiles
	if(tripMiles<0)
	{
		alert('Are you driving in reverse? Trip miles needs to be greater than 0.');
        return(1);
	}
    return(0);
}

function changeColor()
{
	var element = $('#changeMe');
	
	element.classList.toggle('changeable');
}