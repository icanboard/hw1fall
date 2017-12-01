function validateForm()
{
    // Today's Date
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    // /Today's Date

    var DOB = document.getElementById("birthDate").value;
    DOB = DOB.split("-");
    //DOB[0] = Year //DOB[1] = Month //DOB[2] = Day

    // Confirm birthdate is not in the future
    if (DOB[0] > yyyy)
    {
        alert("Birth Date can't be in the future!");
        return false;
    }
    else if (DOB[0] == yyyy)
    {
        if (DOB[1] > mm)
        {
            alert("Birth Date can't be in the future!");
            return false;
        }
        else if (DOB[1] == mm)
        {
            if (DOB[2] > dd)
            {
                alert("Birth Date can't be in the future!");
                return false;
            }
        }
    }
    else
    {   
        return true;
    }
}

function makeAjaxCall(genre)
{
    document.getElementById('output').innerHTML = null;

    $.ajax({
        url: "/Artists/Genre/",
        data: { genre: genre },
        type: "POST",
        //datatype: "json",
        success: function (returnData) { //On Success, Return Images into a grid
            returnData.arr.forEach(function (item) {
                $('#output').append(item);
            }
            )
        }
    });
}