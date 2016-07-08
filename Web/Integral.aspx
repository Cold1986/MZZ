<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Integral.aspx.cs" Inherits="Integral" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
<title>积分兑换</title>
<link href="css/base.css" rel="stylesheet">
<link href="css/integral.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
<div class="wrap">
    <div class="banner"><img src="img/banner.jpg"></div>
    <div class="notice">
        <div class="notice-bg"></div>
        <h3>积分兑换规则（必读）：</h3>
        <p>每人每期只能兑换一件礼品，积分可累积，礼品池定期更新，喜欢的赶紧下手yo~<br/>请仔细填写收货地址，一旦确认无法修改喵~<br/></p>    
    </div>
    <div class="integral">
        <p>您当前的积分为：<span id="Hidintegral" runat="server"></span></p>
        <p>积分不够？每天<a href="#">签到</a>或者戳右上角<span>转发本页</span>到朋友圈，可以获得积分哦！</p>
    </div>
    <div class="list clear_float">
        <div class="clear_float">
            <div class="get-gift left-top">
                
                <asp:Image ID="Image1" runat="server" />
                <i runat="server" id="i1"></i>
                <span class="getGift">兑换</span>
            </div>
            <div class="get-gift right-top">
                <asp:Image ID="Image3"  runat="server" />
                <i runat="server" id="i3"></i>
                <span class="getGift">兑换</span>
            </div>
        </div>
        <div class="clear_float">
            <div class="get-gift left-bottom">
                <asp:Image ID="Image2"  runat="server" />
                <i runat="server" id="i2"></i>
                <span class="getGift">兑换</span>
            </div>
            <div class="get-gift right-bottom">
                <asp:Image ID="Image4"  runat="server" />
                <i runat="server" id="i4"></i>
                <span class="getGift">兑换</span>
            </div>
        </div>
        <div class="get-gift center">
            <asp:Image ID="Image0" runat="server" />
            <i runat="server" id="i0"></i>
            <span class="getGift">兑换</span>
        </div>
    </div>
    
    <div class="popup address">
        <span class="close">x</span>
        <p>
            <label for="inputaddress">收货地址：</label><asp:TextBox ID="inputaddress" placeholder="必填" runat="server"></asp:TextBox>
        </p>
        <p>
            <label for="inputname">收货人：</label><asp:TextBox ID="inputname" placeholder="必填" runat="server"></asp:TextBox>
        </p>
        <p>
            <label for="inputphone">手机号：</label><asp:TextBox ID="inputphone" placeholder="必填" runat="server"></asp:TextBox>
        </p>
        <a href="#" class="submit">提交</a>
    </div>
    <div class="popup confirm" id="confirm">
        <span class="close">x</span>
        <p>信息提交成功！礼品发出后会收到推送通知。请继续关注喵~</p>
        <a href="#" class="close">确认</a>
    </div>
    <div class="popup alert" id="alert">
        <span class="close" style="cursor:pointer">x</span>
        <p>积分不足~</p>
        <a href="#" class="close">确认</a>
    </div>
	<div class="gray"></div>
</div>
        <script src="jssdk/jweixin-1.0.0.js" type="text/javascript"></script>
<script src="js/jquery.js"></script>
<script>
    wx.config({
        debug: false,
        appId: '<%=appId %>',
        timestamp: '<%=timestamp %>',
        nonceStr: '<%=nonceStr %>',
        signature: '<%=signature %>',
        jsApiList: [
        'checkJsApi',
        'onMenuShareTimeline',
        'onMenuShareAppMessage',
        'onMenuShareQQ',
        'onMenuShareWeibo'
        ]
    });
    function shareCallBack() { 
        // 用户确认分享后执行的回调函数
        $.ajax({
            url: "Handler/LntegralHandler.ashx",
            data: {
                act: "share",
                openid: document.getElementById("hidopenid").value
            },
            cache:false,
            success: function (result) {


                var data = $.parseJSON(result);
                if (data.errcode == 0) {
                    alert("分享成功,获取30积分");
                    var integral = document.getElementById("Hidintegral").innerText * 1;
                    integral = integral + 30;
                    document.getElementById("Hidintegral").innerText = integral;

                } else {
                    alert("分享成功,每天只能获取一次积分哦");

                }



            }
        });
    }
    wx.ready(function () {
        var shareData = {
            title: "萌宅族积分兑换",
            desc: "积分兑换,分享此页面给朋友,朋友扫描二维码并关注,既能获取积分哦~",
            link: "<%=shareurl%>",
            imgUrl: '<%=newsPic%>',
            success: shareCallBack
        };

        // 2. 分享接口
        // 2.1 “分享给朋友”
        wx.onMenuShareAppMessage(shareData);
        // 2.2 “分享到朋友圈”
        wx.onMenuShareTimeline(shareData);
        // 2.3 “分享到QQ”
        wx.onMenuShareQQ(shareData);
        // 2.4 “分享到微博”
        wx.onMenuShareWeibo(shareData);
    });

    wx.error(function (res) {
        alert(res.errMsg);
    });




$(".popup .close").click(function(){
	$(this).parent(".popup").hide();
	$(".gray").hide();
	})
$(".get-gift").click(function () {
    if(document.getElementById("HidStatus").value=="1"){
        alert("此次活动您已经兑换过奖品了，请等待下一次活动");
        window.event.returnValue=false;
        return;
    
    }

    var price = $(this).children("i")[0].innerText.replace("P", "") * 1;
    document.getElementById("HidPrizeIntegral").value = price;
    var integral = document.getElementById("Hidintegral").innerText * 1;
    document.getElementById("HidPrizeID").value = $(this).children("i")[0].attributes["prizeID"].value;
    if (integral < price) {
        $(".gray").show();
        $(".alert").show();

    } else {
        $(".gray").show();
        $(".address").show();
    }

	})
$(".submit").click(function () {

    if(document.getElementById("inputaddress").value=="" || document.getElementById("inputname").value=="" || document.getElementById("inputphone").value=="")
    {
    
        alert("请输入必填项");
        window.event.returnValue=false;
        return;

    
    }
        $.ajax({
            url: "Handler/LntegralHandler.ashx",
            data: {
                act: "Lntegral",
                openid: document.getElementById("hidopenid").value,
                prizeid: document.getElementById("HidPrizeID").value,
                address: document.getElementById("inputaddress").value,
                name: document.getElementById("inputname").value,
                cellphone: document.getElementById("inputphone").value
            },
            cache:false,
            success: function (result) {
                var data = $.parseJSON(result);
                if (data.errcode == 0) {
                    $(".submit").parent(".popup").hide();
                    $(".confirm").show();
                }
                else{
                    $(".submit").parent(".popup").hide();
                    $(".confirm").show();
                }
                var integral = document.getElementById("Hidintegral").innerText * 1;
                var prize = document.getElementById("HidPrizeIntegral").value * 1;
                integral = integral - prize;
                document.getElementById("Hidintegral").innerText = integral;
                document.getElementById("HidStatus").value ="1";
            }
        });


	})
$(".gray").click(function(){
	$(".popup").hide();
	$(".gray").hide();
	})
window.onload = function(){
	$(".gray").css("height",$(".wrap").height());
	}
function autoHiden(obj){
	$(obj).hide();
	$(".gray").hide();
	}

</script>


        <asp:HiddenField runat="server" id="hidopenid" value="oNWDuvklEeTEwoLB7l66dNXwF4yc"/>
       
        <asp:HiddenField runat="server" id="HidPrizeID" value=""/>
        <asp:HiddenField runat="server" id="HidPrizeIntegral" value=""/>
        <asp:HiddenField runat="server" id="HidStatus" value=""/>
    </form>
</body>
</html>
