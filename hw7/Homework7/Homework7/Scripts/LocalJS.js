function getSearchResults()
{
    var searchTerms = document.getElementById('searchTerms').value.trim();
    var output = document.getElementById('output');

    if (searchTerms != null || searchTerms != "")
    {
        var topResult = null;
        var rating = null;
        var element = null;
        var termString = searchTerms.split(" ").join('-'); //change spaces to - as Giphy does on their site
        console.log(termString);

        element = document.getElementById('topResult');
        if (element.checked)
        {
            topResult = element.value;
        }
        else
        {
            topResult = "";
        }

        //element = document.getElementsByName('rating').value;
        rating = "&rating=" + $("#rating").val();;

        // Clear the html before appending new results
        $('#output').html(null); 

        $.ajax({
            url: "/Search/",
            type: "POST",
            data: { termString: termString, topResult: topResult, rating: rating },
            success: function (returnData) { //On Success, Return Images into a grid 
                returnData.data.forEach(function (item) {
                    $('#output').append(`<div class="col-lg-4 imgDiv"><img src="${item.images.fixed_height.url}" class="col-lg -4 imgClass"></div>`);
                }
            )}
        });
    }
}
