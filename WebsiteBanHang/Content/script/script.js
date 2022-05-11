const imgPosition = document.querySelectorAll(".slider-container img")
const imgContainer = document.querySelector('.slider-container')
const dotItem = document.querySelectorAll(".dot")
let imgNumber = imgPosition.length
let index = 0
// console.log(imgPosition)
imgPosition.forEach(function(image,index){
    image.style.left = index*100 + "%"
    dotItem[index].addEventListener("click",function(){
    slider(index)
    })
})
function imgSlide (){
    index++;
    console.log(index)
    // function slider(index)
    if(index>=imgNumber) {index=0}
    slider(index)

}
function slider(index) {
    imgContainer.style.left = "-" +index*100+ "%"
    const dotActive = document.querySelector('.active')
    dotActive.classList.remove("active")
    dotItem[index].classList.add("active")
}

setInterval(imgSlide,9000)



const itemsliderbar = document.querySelectorAll(".cartegory-left-li")
itemsliderbar.forEach(function(menu,index){
    menu.addEventListener("click",function(){
        menu.classList.toggle("block")
    })
})





const baohanh = document.querySelector(".baohanh")
const chitiet = document.querySelector(".chitiet")
    if(baohanh){
        baohanh.addEventListener("click",function(){
            document.querySelector(".product-content-right-bottom-content-chitiet").style.display ="none"
            document.querySelector(".product-content-right-bottom-content-baohanh").style.display ="block"
        })
    }
    if(chitiet){
        chitiet.addEventListener("click",function(){
            document.querySelector(".product-content-right-bottom-content-chitiet").style.display ="block"
            document.querySelector(".product-content-right-bottom-content-baohanh").style.display ="none"
        })
    }
    const button = document.querySelector(".product-content-right-bottom-top")
    if(button){
        button.addEventListener("click",function(){
            document.querySelector(".product-content-right-bottom-content-big").classList.toggle("activeB")
        })
    }