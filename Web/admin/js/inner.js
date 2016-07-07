var list_style={
		list1:function(){
				if(!$(".list_1")){return;}
				$(".list_1 tr:even").not(".list_1 tr[class=title1]").find("td").addClass("even");
			},
		imgBig:function(){
				var _thisHeight;
				var _thisWidth;
				if(!$(".list_1")){return;}
				$(".list_1 img").bind("mouseover",function(){
					
					$(this).parent().css("position","relative")
					_thisHeight=$(this).height();
					_thisWidth=$(this).width();
					var TheImage=new Image();
					TheImage.src=$(this).attr("src");
					var blockDiv=$("<div style='height:"+_thisHeight+"px;width:"+_thisWidth+"px'></div>")
					//alert(_thisHeight+"<br>"+_thisWidth+"<br>"+TheImage.width+"<br>"+TheImage.height)
					$(this).addClass("selected");
					//$(this).css({"left":"-"+(_thisHeight/2)+"px","right":"-"+(_thisWidth/2)+"px"})
					$(this).parent().append(blockDiv);
					$(this).stop().css({height:TheImage.height+"px",width:TheImage.width+"px",marginLeft:"-"+(TheImage.width)/2+"px",marginTop:"-"+(TheImage.height)/2+"px"})
					}).bind("mouseout",function(){
					$(this).stop().css({height:_thisHeight+"px",width:_thisWidth+"px",marginLeft:"0px",marginTop:"0px"})
					$(this).removeClass("selected");
					$(this).parent().find("div").remove();	
					})
				},
		edit_box:function(){
				$("a.floattable").click(function(){
						var divleft=$(this).offset().left;
						var divtop=$(this).offset().top;
						$(".edit_box").append("<iframe src='"+$(this).attr("rel")+"' scrolling='auto' frameborder='0' width='800' height='415'></iframe>")
						
						$(".edit_box").css({left:divleft+"px",top:divtop+"px"}).animate({"opacity":"1","left":"50%","top":"50%","marginLeft":"-400px","marginTop":"-225px","height":"450px","width":"800px"},"slow")
						$(".add_bg2").show().animate({opacity:0.4},"fast");
						$(".edit_box h1 a").bind("click",(function(){
								$(".edit_box").animate({"opacity":"0","left":divleft+"px","top":divtop+"px","marginLeft":"0px","marginTop":"0px","height":"40px","width":"40px"},"slow",function(){$(".edit_box").css({left:"0px",top:"0px"})
								divtop="";
								$(".edit_box").find("iframe").remove();
								$(".add_bg2").show().animate({opacity:0},"slow",function(){
										$(".add_bg2").hide()
									});
								})
								$(this).unbind();
								
							}))
					})
			},
		dragDiv:function(obj){
				var dragging = false;
				var iX, iY;
				obj.mousedown(function(e) {
					dragging = true;
					iX = e.clientX - $(this).position().left;
					iY = e.clientY - $(this).position().top;
					this.setCapture && this.setCapture();
					return false;
				});
				document.onmousemove = function(e) {
					if (dragging) {
						var e = e || window.event;
						var oX = e.clientX - iX;
						var oY = e.clientY - iY;
						obj.css({"left":oX + "px", "top":oY + "px"});
						return false;
					}
				};
				$(document).mouseup(function(e) {
					dragging = false;
					//obj[0].releaseCapture();
					e.cancelBubble = true;
				})
			},
		
			table_bg:function(){
					$(".em_t").find("tr:odd").css("background","#ffffff")
					$(".em_t tr:not(first)").hover(function(){
							$(this).css("background","#fefeda")
						},function(){
							$(".em_t").find("tr:even").css("background","none")
								$(".em_t").find("tr:odd").css("background","#ffffff")
							})
			},
			
			slideTop:function(Array1,Array2){
					$(Array1).click(function(){
						//alert($(Array2[$(this).index()]).position().top)
						$(this).children("a").addClass("btn-blue").end().siblings("li").children("a").removeClass("btn-blue");
							$("html,body").stop().animate({scrollTop:$(Array2[$(this).index()]).offset().top},1000)
						})
				},
			
			member_box:function(){
					$(".member_box .close a").click(function(){
							$(".member_box").stop().animate({"right":"-200px"})
						})
					$("a[type=member_box]").click(function(){
							
						
							$.ajax({
							type:"get",
							url:$(this).attr("rel")+"&"+Math.random(),
							contenttype :"application/x-www-form-urlencoded;charset=gb2312", 
							success:function(rText){
							$("#member_c").html(rText);
								 list_style.edit_box();
								list_style.member_slide();
								}
							})
							
							//$(".member_box").find("iframe").attr("src",$(this).attr("rel"))
							$(".member_box").stop().animate({"right":"0px"})
						})
					
					
					
				},
			
			member_slide:function(){
					$(".member_data li").each(function(){
							var str;
							str=$(this).find("a").text();
							if(str == "") return;
							var arrRslt = makePy(str);
							$(".font_block[font="+arrRslt+"]").find("ul").append($(this));
						})
					$(".search_font a").click(function(){
						//alert($(this).index()+"<br>"+$(".font_block").eq($(this).index()).position().top+"<br>"+$(".font_block").eq($(this).index()).offset().top+"<br>"+$(".search_font").height())
							$("#member_c").stop().animate({scrollTop:$("#member_c").scrollTop()+$(".font_block").eq($(this).index()-1).position().top-$(".search_font").height()},500)
							
						})
				}
				
			
			
			
}

						
$(document).ready(function(){
	list_style.edit_box();
	 list_style.list1();
	 list_style.imgBig();
	 
	 list_style.table_bg();
	 list_style.member_box();
	 })
	
	