var currentNumber = -1;

function NextCard(jsonDeck) {
    if (currentNumber < jsonDeck.Cards.length - 1) 
    {
        currentNumber = currentNumber + 1;
        document.getElementById('ci').src = jsonDeck.Cards[currentNumber].ImageUrl;
    } 
    else 
    {
        document.getElementById('ci').src = "/Content/Empty.png";
        document.getElementById('btn_next').disabled = true;
    }
}

function ShuffleCards(jsonDeck) {
    $.ajax({
        url: "/Home/ShuffleCards",
    //    @*url: '@Url.Action("ShuffleCards")',*@
        data: JSON.stringify(jsonDeck),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        type: "POST",
        success: function (response) {
            jsonDeck.Cards = response;
            currentNumber = -1;
            document.getElementById('ci').src = "/Content/0Front.png";
            document.getElementById('btn_next').disabled = false;
            alert("Card shuffeled!");//TODO: create a better way to communicate with user
        }
    });
};

function SortCards(jsonDeck) {
    $.ajax({
        url: "/Home/SortCards",
        //@*url: '@Url.Action("SortCards")',*@
        data: JSON.stringify(jsonDeck),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        type: "POST",
        success: function (response) {
            jsonDeck.Cards = response;
            currentNumber = -1;
            document.getElementById('ci').src = "/Content/0Front.png";
            document.getElementById('btn_next').disabled = false;
            alert("Card Sorted!");//TODO: create a better way to communicate with user
        }
    });
};