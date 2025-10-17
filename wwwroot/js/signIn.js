// Lấy phần tử
    const btnSignIn = document.getElementById("btnSignIn");
    const modal = document.getElementById("modalSignIn");
    const btnClose = document.getElementById("btnClose");

    // Khi click vào nút -> hiện modal
    btnSignIn.onclick = function () {
        modal.style.display = "flex";
        };

    // Khi click nút Đóng -> ẩn modal
    btnClose.onclick = function () {
        modal.style.display = "none";
        };

    // Khi click ra ngoài modal -> ẩn modal
    window.onclick = function (event) {
          if (event.target === modal) {
        modal.style.display = "none";
          }
};
document.addEventListener("DOMContentLoaded", () => {
    const linkDangKy = document.querySelector(".SignInModal-noAccount a");
    const loginDangNhap = document.querySelector(".SignInModal-login:not(.SignInModal-register)");
    const loginDangKy = document.querySelector(".SignInModal-register");

    if (linkDangKy && loginDangNhap && loginDangKy) {
        linkDangKy.addEventListener("click", (e) => {
            e.preventDefault();
            // Ẩn phần đăng nhập, hiện đăng ký
            loginDangNhap.style.display = "none";
            loginDangKy.style.display = "block";
        });
    }

    // Ngược lại: khi bấm “Đăng nhập” ở form đăng ký
    const linkDangNhap = document.querySelector(".SignInModal-register .SignInModal-noAccount a");
    if (linkDangNhap) {
        linkDangNhap.addEventListener("click", (e) => {
            e.preventDefault();
            loginDangKy.style.display = "none";
            loginDangNhap.style.display = "block";
        });
    }
});
document.addEventListener("DOMContentLoaded", function () {
    var shouldOpenModal = '@(ViewBag.ShowModal?.ToString().ToLower() ?? "false")';

    if (shouldOpenModal === 'true') {
        document.getElementById("modalSignIn").style.display = "block";
    }
});

document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("checkEmailForm");
    const emailInput = document.getElementById("newEmail");
    const errorSpan = document.getElementById("emailError");

    form.addEventListener("submit", function (e) {
        e.preventDefault(); // chặn submit thật

        const email = emailInput.value.trim();

        // Gửi AJAX đến Controller
        fetch('/Account/CheckEmail', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: new URLSearchParams({ newEmail: email })
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    // Nếu chưa có email → chuyển bước kế tiếp
                    window.location.href = data.redirectUrl;
                } else {
                    // Nếu email đã tồn tại → hiện thông báo lỗi
                    errorSpan.textContent = data.message;
                }
            })
            .catch(err => {
                console.error('Lỗi:', err);
            });
    });
});
