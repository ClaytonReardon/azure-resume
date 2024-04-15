window.addEventListener('DOMContentLoaded', (event) =>{
    getVisitCount();
})

const functionApiUrl = "https://getazureresume.azurewebsites.net/api/GetResumeCounter?code=eW9ypS67fHOtUnmh2xM_pDueZBgANTs-FKGG643_uvC9AzFuTLgMeA==";

const getVisitCount = () => {
    let count = 30;
    fetch(functionApiUrl).then(response => {
        return response.json()
    }).then(response =>{
        console.log("Website called function API.");
        count = response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error){
        console.log(error);
    });
    return count;
}