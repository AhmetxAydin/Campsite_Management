<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Campsite_Management.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <main>
        <section id="showcase">
            <div class="content">
                <h2 style="color: #ffff; font-size: 45px; font-family: 'Brush Script MT', cursive;">Welcome to CampingAPP</h2>
                <h3 style="color: #ffff;">Enjoy nature and find peace under the stars. Discover the joy of camping with us!
                </h3>
            </div>
        </section>
        <br>
        <section id="options">
            <h2 class="section-title">Are you ready for an adventure in the lap of nature?</h2>

            <div class="container">
                <div class="row">

                    <div class="col-3 card-container">
                        <div class="card">
                            <img class="card-image  img-fluid" src="images/pexels-amine-m'siouri-2108845.jpg" alt="">
                            <div class="card-body">
                                <h2 style="font-size:25px">Hiking</h2>
                                <br> <br>
                                <p>
                                    Are you ready to discover yourself in the unique atmosphere of nature walks? Discover
                                    the miracles of nature, relax and renew your soul as you go step by step. Nature
                                    walks renew not only your body but also your soul. As you feel freer with each step,
                                    you will be mesmerised by the natural beauties around you.
                                </p>
                                 <br><br> 
                            
                            </div>
                        </div>
                    </div>
                    <div class="col-3 card-container">
                        <div class="card">
                            <img class="card-image  img-fluid" src="images/pexels-felix-mittermeier-2832034.jpg" alt="">
                            <div class="card-body">
                                <h2 style="font-size:25px" >Hut Accommodation</h2>
                               <br> <br>
                                <p>
                                    Get away from the hustle and bustle of the city and find peace in the embracing
                                    serenity of nature. Baraka accommodation is the best way to get away from the hustle
                                    and bustle of modern life and take a quiet break. There is nothing like sleeping
                                    peacefully with the sounds of nature and meeting a new day in the cool of the
                                    morning.
                                </p>
                                 <br>
                           
                            </div>
                        </div>
                    </div>
                    <div class="col-3 card-container">
                        <div class="card">
                            <img class="card-image  img-fluid" src="images/pexels-taryn-elliott-6861137.jpg" alt="">
                            <div class="card-body">
                                <h2 style="font-size:25px">Camp</h2>
                                <br> <br>
                                <p>
                                    Step into the fascinating world of camping! Enjoy the moments intertwined with
                                    nature, enjoy the adventure and freedom to the fullest. You can adventure in the lap
                                    of nature during the day and gather around the fire in the evening to relieve the
                                    tiredness of the day. You can also make new friends while enjoying camping.

                                </p>
                                <br> <br>
                            
                            </div>
                        </div>
                    </div>

                    <div class="col-3 card-container">
                        <div class="card">
                            <img class="card-image  img-fluid" src="images/pexels-pavel-danilyuk-9143896.jpg" alt="">
                            <div class="card-body">
                                <h2 style="font-size:25px">Fireside Chats</h2>
                                <br> <br>
                                <p>
                                    How about feeling the intimacy of coming together by the fire? Make new friendships
                                    by having moments full of warm conversations and enjoy the nights around the
                                    campfire. Fireside chats allow us not only to listen to each other, but also to
                                    really connect with each other. Stories shared under the stars, in the warmth of the
                                    fire, turn into unforgettable memories.
                                </p>
                               
                             
                            </div>
                        </div>
                    </div>


                </div>

            </div>

        </section>
        <br>
        <br>
        <br>
    </main>

    

    <footer class="new_footer_area bg_color">
        <div class="new_footer_top">
            <div class="container">
                <div class="row">
                    <div class="col-lg-3 col-md-6">
                        <div class="f_widget company_widget wow fadeInLeft" data-wow-delay="0.2s"
                            style="visibility: visible; animation-delay: 0.2s; animation-name: fadeInLeft;">
                            <h3 class="f-title f_600 t_color f_size_18">Get in Touch</h3>
                            <p>Are you having a problem?</p>

                            <form action="#" class="f_subscribe_two mailchimp" method="post" novalidate="true"
                                _lpchecked="1">
                                <a class="btn btn_get btn_get_two" href="Contact.html">contact
                                    with us</a>
                                <p class="mchimp-errmessage" style="display: none;"></p>
                                <p class="mchimp-sucmessage" style="display: none;"></p>
                            </form>

                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="f_widget about-widget pl_70 wow fadeInLeft" data-wow-delay="0.4s"
                            style="visibility: visible; animation-delay: 0.4s; animation-name: fadeInLeft;">
                            <ul class="list-unstyled f_list">
                                <li><a href="#">Company</a></li>
                                <li><a href="#">Projects</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="f_widget about-widget pl_70 wow fadeInLeft" data-wow-delay="0.6s"
                            style="visibility: visible; animation-delay: 0.6s; animation-name: fadeInLeft;">
                            <h3 class="f-title f_600 t_color f_size_18">Help</h3>
                            <ul class="list-unstyled f_list">
                                <li><a href="#">Term &amp; conditions</a></li>
                                <li><a href="#">Support Policy</a></li>
                                <li><a href="#">Privacy</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="f_widget social-widget pl_70 wow fadeInLeft" data-wow-delay="0.8s"
                            style="visibility: visible; animation-delay: 0.8s; animation-name: fadeInLeft;">
                            <h3 class="f-title f_600 t_color f_size_18">Team Solutions</h3>
                            <div class="f_social_icon">
                                <a href="#" class="fab fa-twitter"></a>
                                <a href="https://www.linkedin.com/in/ahmet-yasin-ayd%C4%B1n-9466982b1/" target="_blank"
                                    class="fab fa-linkedin"></a>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer_bg">
                <div class="footer_bg_one"></div>
                <div class="footer_bg_two"></div>
            </div>

        </div>

    </footer>

</asp:Content>
