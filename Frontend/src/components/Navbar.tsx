import { IoMenu } from "react-icons/io5";
import { useRef, useState } from "react";
import useClickOutside from "../hooks/useClickOutside.tsx";
import { useNavigate } from "react-router-dom";

type NavbarProps = {
	pageTitle: string;
};

const Navbar = (props: NavbarProps) => {
	const { pageTitle } = props;

	const menuItems = ["Home", "About", "Contact"];

	const navigate = useNavigate();

	const [menuOpen, setMenuOpen] = useState<boolean>(false);

	const menuButtonRef = useRef<HTMLDivElement>(null);
	const menuRef = useRef<HTMLDivElement>(null);
	useClickOutside([menuButtonRef, menuRef], () => setMenuOpen(false));

	return (
		<>
			<div
				className={
					"fixed flex h-10 w-full justify-between bg-white_transparent px-2 py-1"
				}
			>
				<div className={"flex gap-2"}>
					<div ref={menuButtonRef}>
						<IoMenu
							className={"h-8 w-8 cursor-pointer"}
							onClick={() => setMenuOpen(!menuOpen)}
						/>
					</div>

					<img
						src={"/CodeClubLogo.png"}
						alt={"Code Club"}
						className={"h-8 w-8 cursor-pointer"}
					/>
				</div>

				<div>
					<div
						className={
							"flex h-8 cursor-pointer items-center justify-center rounded-lg border-2 border-black bg-white px-2"
						}
					>
						Login
					</div>
				</div>
			</div>

			<div
				ref={menuRef}
				className={`transition-[max-height, transform] fixed top-10 z-10 overflow-hidden bg-white_transparent duration-500 ${menuOpen ? "max-h-[90vh] transform-none" : "max-h-0 transform"}`}
			>
				<div className={"flex flex-col gap-1 px-2 py-1"}>
					{menuItems.map((item, index) => (
						<div
							key={index}
							className={`flex cursor-pointer items-center justify-center rounded-lg px-2 py-1 hover:bg-light_gray ${item === pageTitle && "bg-light_gray"}`}
							onClick={() => navigate(`/${item.toLowerCase()}`)}
						>
							{item}
						</div>
					))}
				</div>
			</div>
		</>
	);
};

export default Navbar;
