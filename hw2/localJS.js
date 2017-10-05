//This function calculates miles/mpg * ppg and creating a table displaying relevant information
//accordingly. Uses mpg, ppg, and tripMiles.
function calculatePrices()
{
	var outputDiv = document.getElementById('tableOutput');
	var mpg = document.getElementById('mpg').value;
	var ppg = document.getElementById('ppg').value;
	var tripMiles = document.getElementById('tripMiles').value;
	var outputString = '';
	var mpgTemp = mpg;
	var tripMilesTemp = tripMiles;
	ppg = ppg.split('$');
	ppg = parseFloat(ppg[1]);
	

	//validate empty strings
	if(mpg == '' || ppg == '$' || ppg == '' || tripMiles == '')
	{
		alert("You must use a valid value for Price per Gallon and Miles per Gallon.");
		return(1);
	}
	
	//validate ppg is valid
	if(ppg<=0)
	{
		alert("Free gas? Hook me up!");
		return(1);
	}
	if(ppg>'10')
	{
		alert("Is that a realistic price for gas? I'm saying no way!");
		return(1);
	}
	
	//validate mpg is valid
	if(mpg<5)
	{
		alert("Your car can't possible have that bad mpg! It has to be 5 or higher.");
		return(1);
	}	
	if(mpg>60)
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
	
	//start building the table
		outputString = '<table>';
	
	//build table
	for(var i=0; i<5; i++)
	{
		//build headers first
		if(i==0)
		{
			//k-1 number of headers headers
			for(var k=0; k<11; k++)
			{
				//build tr before adding th and make an empty th for k=0
				if(k==0)
				{
					outputString += '<tr><th></th>';
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
				//console.log('tripMilesTemp: ' + tripMilesTemp + ' mpgTemp: ' + mpgTemp + ' ppg: ' + ppg);
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
	outputDiv.innerHTML = outputString;
}